using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ClientsController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetClient()
        {
            var clients = await _dataService.GetAllClient();
            return Ok(clients);
        }

        //[HttpGet]
        //[Route("clients/email/{email}")]
        //public async Task<IActionResult> GetClientByEmail(string email)
        //{
        //    var client = await _dataService.GetClientByEmail(email);
        //    return Ok(client);
        //}

        [HttpGet]
        [Route("clients/id/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _dataService.GetClientById(id);
            return Ok(client);
        }
    }
}
