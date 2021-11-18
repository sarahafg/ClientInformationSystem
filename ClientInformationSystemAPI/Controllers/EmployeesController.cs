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
    public class EmployeesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public EmployeesController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetEmployee()
        {
            var employees = await _dataService.GetAllEmployee();
            return Ok(employees);
        }

        [HttpGet]
        [Route("employees/name/{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee = await _dataService.GetEmployeeByName(name);
            return Ok(employee);
        }

        [HttpGet]
        [Route("employees/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _dataService.GetEmployeeById(id);
            return Ok(employee);
        }
    }
}
