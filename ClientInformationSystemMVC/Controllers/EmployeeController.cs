using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ClientInformationSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDataService _dataService;

        public EmployeeController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            InteractionPageViewModel intModel = new InteractionPageViewModel { header = new HeaderViewModel() };
            intModel.header.clientDropDown = await _dataService.GetAllClient();
            intModel.header.employeeDropDown = await _dataService.GetAllEmployee();
            if (intModel == null)
            {
                return View();
            }
            return View(intModel);
            //return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var employeeCards = await _dataService.GetAllEmployee();
            if (!employeeCards.Any())
            {
                return View();
            }
            return View(employeeCards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
