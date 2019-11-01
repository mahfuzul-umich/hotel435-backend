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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<List<Room>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Room> GetByIdAsync(string id)
        {
            return await _service.GetByIdAsync(id);
        }

        //NOTE: Current requirements do not mandate an Insert method so will be left alone for now
        // POST: api/Rooms
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        //NOTE: Current requirements do not mandate an Update method so will be left alone for now
        // PUT: api/Rooms/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //NOTE: Current requirements do not mandate a Delete method so will be left alone for now
        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
