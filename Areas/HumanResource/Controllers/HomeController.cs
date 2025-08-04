using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.HumanResource.Controllers;

[Area("HumanResource")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        this._logger = logger;
    }
    // GET: /HumanResource
    public IActionResult Index()
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        _logger.LogInformation("{ipAddress} visited HumanResource page", ipAddress);
        return View();
    }
}