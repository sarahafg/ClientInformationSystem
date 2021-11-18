using ApplicationCore.ServiceInterfaces;
using ClientInformationSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var interCards = await _dataService.GetAllEmployee();
            if (!interCards.Any())
            {
                return View();
            }
            return View(interCards);
            //return View();
        }

        public async Task<IActionResult> Employees()
        {
            var employeeCards = await _dataService.GetAllEmployee();
            if (!employeeCards.Any())
            {
                return View();
            }
            return View(employeeCards);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
