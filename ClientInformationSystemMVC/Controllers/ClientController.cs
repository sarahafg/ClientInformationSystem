using ApplicationCore.Models;
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
            ClientPageViewModel intModel = new ClientPageViewModel { header = new HeaderViewModel() };
            intModel.header.clientDropDown = await _dataService.GetAllClient();
            intModel.header.employeeDropDown = await _dataService.GetAllEmployee();
            if (intModel == null)
            {
                return View();
            }
            return View();
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> ClientList()

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
            var clientCards = await _dataService.GetAllClient();
            if (!clientCards.Any())
            {
                return View();
            }
            return View(clientCards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
