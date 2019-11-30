using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using hotel435.Models;

namespace hotel435.Services
{
    public class MailService : IMailService
    {
        private readonly Hotel435DbContext _dbContext;

        public MailService(Hotel435DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> SendConfirmationEmail(string reservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(reservationId);
            var room = await _dbContext.Rooms.FindAsync(reservation.RoomId);

            if (reservation != null)
            {
                DateTime? CheckIn;
                DateTime? CheckOut;

                if (reservation.ActualCheckIn != null && reservation.ActualCheckOut == null)
                { 
                    CheckIn = reservation.ActualCheckIn;
                    CheckOut = DateTime.UtcNow;
                }
                else
                {
                    CheckIn = reservation.CheckIn;
                    CheckOut = reservation.CheckOut;
                }

                var price = (double)room.Price;

                var time = CheckOut.Value.Subtract(CheckIn.Value);
                if (time.TotalDays > 1.0) price = time.TotalDays * price; //if more than one day has passed, calculate new price

                reservation.Price = (decimal)price;
                _dbContext.Reservations.Update(reservation);
                await _dbContext.SaveChangesAsync();

                // after updating the reservation model, send an email confirmation to user
                var builder = new StringBuilder();

                using var reader = System.IO.File.OpenText("EmailTemplate/template.html");
                builder.Append(reader.ReadToEnd());

                builder.Replace("{{name}}", $"{reservation.FirstName} {reservation.LastName}");
                builder.Replace("{{checkIn}}", $"{CheckIn.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
                builder.Replace("{{checkOut}}", $"{CheckOut.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
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
