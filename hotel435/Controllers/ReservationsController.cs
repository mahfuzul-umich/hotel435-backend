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

        [HttpGet("{id}")]
        public async Task<Reservation> GetByIdAsync(string id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Reservation> InsertAsync([FromBody] Reservation model)
        {
            return await _service.InsertAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _service.DeleteAsync(id);
        }
    }
}