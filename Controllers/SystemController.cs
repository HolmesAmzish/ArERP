using ArERP.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Controllers;


public class SystemController : Controller
{
    private readonly ISystemService _systemService;
    private readonly ILogger<SystemController> _logger;
    
    public SystemController(ISystemService systemService, ILogger<SystemController> logger)
    {
        this._systemService = systemService;
        this._logger = logger;
    }

    // GET: /System/Index
    public IActionResult Index()
    {
        var systemLogs = _systemService.GetAllSystemLogs();
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        _logger.LogInformation("{ipAddress} visited System logs page", ipAddress);
        return View(systemLogs);
    }
    
}