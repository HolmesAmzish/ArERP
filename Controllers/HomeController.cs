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

        public HomeController(
            ILogger<HomeController> logger,
            IDashboardService dashboardService
        )
        {
            this._logger = logger;
            this._dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation("{ipAddress} visited Homepage", ipAddress);
            return View();
        }
        
        // GET: /Home/Dashboard
        public IActionResult Dashboard(int pageIndex = 1, int pageSize = 10)
        {
            ViewBag.shiftStats = _dashboardService.GetEmployeeShiftStats();
            ViewBag.workshopStats = _dashboardService.GetWorkshopStats();

            var pagedWorkOrders = _dashboardService.GetWorkOrders(pageIndex, pageSize);
            ViewBag.workOrders = pagedWorkOrders.Items;
            ViewBag.WorkOrdersTotalCount = pagedWorkOrders.TotalCount;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;

            ViewBag.workOrderStats = _dashboardService.GetWorkOrderStats();
            ViewBag.productionStats = _dashboardService.GetAllProductionTransactions();
            ViewBag.machineStats = _dashboardService.GetMachineStats();
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation("{ipAddress} visited Dashboard page", ipAddress);
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult License() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}