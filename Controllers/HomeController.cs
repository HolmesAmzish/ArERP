using ArERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ArERP.Service;

namespace ArERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;

        public HomeController(ILogger<HomeController> logger, IDashboardService dashboardService)
        {
            this._logger = logger;
            this._dashboardService = dashboardService;
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            ViewBag.shiftStats = _dashboardService.GetEmployeeShiftStats();
            ViewBag.workshopStats = _dashboardService.GetWorkshopStats();
            return View();
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
