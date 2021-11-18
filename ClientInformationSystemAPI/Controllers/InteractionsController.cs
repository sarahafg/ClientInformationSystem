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
    public class InteractionsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public InteractionsController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("interactions")]
        public async Task<IActionResult> GetInteraction()
        {
            var inters = await _dataService.GetAllInteraction();
            if (!inters.Any())
            {
                return Ok();
            }
            return Ok(inters);
        }

        [HttpGet]
        [Route("interactions/{id}")]
        public async Task<IActionResult> GetInteractionById(int id)
        {
            var client = await _dataService.GetInteractionById(id);
            return Ok(client);
        }

        [HttpGet]
        [Route("interactions/client/{ClientId}")]
        public async Task<IActionResult> GetInteractionByClientId(int ClientId)
        {
            var inter = await _dataService.GetInteractionByClientId(ClientId);
            return Ok(inter);
        }

        [HttpGet]
        [Route("interactions/employee/{EmpId}")]
        public async Task<IActionResult> GetInteractionByEmpId(int EmpId)
        {
            var inter = await _dataService.GetInteractionByEmpId(EmpId);
            return Ok(inter);
        }

        [HttpGet]
        [Route("interactions/client/remarks/{ClientId}")]
        public async Task<IActionResult> GetRemarksByClientId(int ClientId)
        {
            var inter = await _dataService.GetRemarksByClientId(ClientId);
            return Ok(inter);
        }
        
    }
}
