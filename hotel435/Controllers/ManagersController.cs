using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;
using hotel435.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel435.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagersController(IManagerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> InsertAsync(Manager model)
        {
            var resource = await _service.InsertAsync(model);
            return resource;
        }
    }
}
