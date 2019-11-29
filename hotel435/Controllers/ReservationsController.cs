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

        public ReservationsController(IReservationService service)
        {
            _service = service;
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
            model.Price = 0;
            model.ActualCheckIn = null;
            model.ActualCheckOut = null;
            model.CheckIn = model.CheckIn.ToUniversalTime();
            model.CheckOut = model.CheckOut.ToUniversalTime();

            Guid guid = Guid.NewGuid();
            string confirmationNumber = Convert.ToBase64String(guid.ToByteArray());
            confirmationNumber = confirmationNumber.Replace("=", "")
                                                   .Replace("+", "")
                                                   .Replace("/", "");
            model.ConfirmationNumber = confirmationNumber;
            return await _service.InsertAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _service.DeleteAsync(id);
        }
    }
}