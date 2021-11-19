using ApplicationCore.ServiceInterfaces;
using ClientInformationSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemMVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDataService _dataService;

        public ClientController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var interCards = await _dataService.GetAllClient();
            if (!interCards.Any())
            {
                return View();
            }
            return View(interCards);
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
