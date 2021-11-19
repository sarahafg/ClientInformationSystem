using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ClientInformationSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemMVC.Controllers
{
    public class InteractionController : Controller
    {
        private readonly IDataService _dataService;

        public InteractionController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            InteractionPageViewModel intModel = new InteractionPageViewModel { header = new HeaderViewModel() };
            intModel.header.clientDropDown = await _dataService.GetAllClient();
            intModel.header.employeeDropDown = await _dataService.GetAllEmployee();
            intModel.interaction = await _dataService.GetAllInteraction();
            if (intModel == null)
            {
                return View();
            }
            return View(intModel);
        }

        public async Task<IActionResult> Privacy()
        {
            var interCards = await _dataService.GetAllInteraction();
            if (!interCards.Any())
            {
                return View();
            }
            return View(interCards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
