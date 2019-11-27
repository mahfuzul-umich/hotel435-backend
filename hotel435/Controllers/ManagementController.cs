using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;
using hotel435.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel435.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ManagementController : Controller
    {
        private readonly IManagementService _service;

        public ManagementController(IManagementService service)
        {
            _service = service;
        }

        [HttpGet("reservations")]
        public List<ManagementReservationViewModel> GetManagementReservationViewModel()
        {
            return _service.GetManagementReservationViewModel();
        }

        [HttpPost("checkin/{reservationId}")]
        public async Task<Reservation> SetReservationCheckInDate(string reservationId)
        {
            var reservation = await _service.SetReservationCheckInDate(reservationId);

            // return the modified reservation. if it's null, there was a validation error or no reservation was found
            return reservation;
        }

        [HttpPost("checkout/{reservationId}")]
        public async Task<Reservation> SetReservationCheckOutDate(string reservationId)
        {
            var reservation = await _service.SetReservationCheckOutDate(reservationId);

            // return the modified reservation. if it's null, there was a validation error or no reservation was found
            return reservation;
        }
    }
}
