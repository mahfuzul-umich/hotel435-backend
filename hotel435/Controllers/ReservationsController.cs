using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;
using hotel435.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel435.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IRoomService _roomService;
        private readonly IMailService _mailService;

        public ReservationsController(IReservationService service, IRoomService roomService, IMailService mailService)
        {
            _service = service;
            _roomService = roomService;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{confirmationNumber}")]
        public Reservation GetByConfirmationNumber(string confirmationNumber)
        {
            return _service.GetReservationByConfirmationNumber(confirmationNumber);
        }

        [HttpPost]
        public async Task<Reservation> InsertAsync([FromBody] Reservation model)
        {
            // since price, actual check in and actual check out can't be set by the user, ensure they're set to default values
            model.ActualCheckIn = null;
            model.ActualCheckOut = null;
            model.CheckIn = model.CheckIn.ToUniversalTime();
            model.CheckOut = model.CheckOut.ToUniversalTime();
            var room = await _roomService.GetByIdAsync(model.RoomId);
            model.Price = ((decimal) model.CheckOut.Subtract(model.CheckIn).TotalDays) * room.Price; //default price to (expectedcheckout - expectedcheckin) * price per night

            Guid guid = Guid.NewGuid();
            string confirmationNumber = Convert.ToBase64String(guid.ToByteArray());
            confirmationNumber = confirmationNumber.Replace("=", "")
                                                   .Replace("+", "")
                                                   .Replace("/", "");
            model.ConfirmationNumber = confirmationNumber;

            var reservation = await _service.InsertAsync(model);
            await _mailService.SendConfirmationEmailAsync(reservation); //send email confirmation when reservation is created

            return reservation;
        }

        [HttpDelete("{confirmationNumber}")]
        public async Task RemoveByConfirmationNumberAsync(string confirmationNumber)
        {
            await _service.RemoveReservationByConfirmationNumber(confirmationNumber);
        }
    }
}