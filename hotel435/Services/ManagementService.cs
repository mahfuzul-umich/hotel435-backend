﻿using hotel435.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public class ManagementService : IManagementService
    {
        private readonly Hotel435DbContext _dbContext;

        public ManagementService(Hotel435DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ManagementReservationViewModel> GetManagementReservationViewModel()
        {
            var reservationsWithRooms = new List<ManagementReservationViewModel>();
            var result = _dbContext.Reservations.Join(
                _dbContext.Rooms,
                reservation => reservation.RoomId,
                room => room.Id,
                (reservation, room) => new { Reservation = reservation, Room = room });
            foreach (var record in result)
            {
                reservationsWithRooms.Add(new ManagementReservationViewModel { Reservation = record.Reservation, Room = record.Room });
            }
            return reservationsWithRooms;
        }

        /// <inheritdoc />
        public async Task<Reservation> SetReservationCheckInDate(string reservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(reservationId);

            //only allow manager to set actual check in date if actual check in and check out date dont yet exist already
            if (reservation != null && reservation.ActualCheckIn == null && reservation.ActualCheckOut == null)
            {
                reservation.ActualCheckIn = DateTime.UtcNow;
                _dbContext.Reservations.Update(reservation);
                await _dbContext.SaveChangesAsync();
                return reservation;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<Reservation> FinalizeReservation(string reservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(reservationId);
            var room = await _dbContext.Rooms.FindAsync(reservation.RoomId);

            //only allow managers to set actual check out date if actual check in date is already set and check out date isn't
            if (reservation != null && reservation.ActualCheckIn != null && reservation.ActualCheckOut == null)
            {
                reservation.ActualCheckOut = DateTime.UtcNow;

                var price = (double) room.Price; // by default, price of reservation is 1 night which is the price listed in the room model
                var time = reservation.ActualCheckOut.Value.Subtract(reservation.ActualCheckIn.Value);
                if (time.TotalDays > 1.0) price = time.TotalDays * price; //if more than one day has passed, calculate new price
                reservation.Price = (decimal) price;

                _dbContext.Reservations.Update(reservation);
                await _dbContext.SaveChangesAsync();

                // after updating the reservation model, send an email confirmation to user
                var builder = new StringBuilder();

                using var reader = System.IO.File.OpenText("EmailTemplate/template.html");
                builder.Append(reader.ReadToEnd());

                builder.Replace("{{name}}", $"{reservation.FirstName} {reservation.LastName}");
                builder.Replace("{{checkIn}}", $"{reservation.ActualCheckIn.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
                builder.Replace("{{checkOut}}", $"{reservation.ActualCheckOut.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
                builder.Replace("{{amount}}", $"${reservation.Price}");
                builder.Replace("{{confirmation}}", $"{reservation.ConfirmationNumber}");

                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("cis435hotel435@gmail.com", "Cis435Hotel435!")
                };

                using (var message = new MailMessage("cis435hotel435@gmail.com", $"{reservation.Email}")
                {
                    Subject = "Hotel435 Confirmation",
                    Body = builder.ToString(),
                    IsBodyHtml = true
                })
                {
                    await smtpClient.SendMailAsync(message);
                }
                return reservation;
            }

            return null;
        }
    }
}
