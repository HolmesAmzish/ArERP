using ArERP.Dtos;
using ArERP.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Controllers;


public class SystemController : Controller
{
    private readonly ISystemLogService _systemLogService;
    private readonly ILogger<SystemController> _logger;

    public SystemController(ISystemLogService systemLogService, ILogger<SystemController> logger)
    {
        this._systemLogService = systemLogService;
        this._logger = logger;
    }

    // GET: /System/Index
    public IActionResult Index(int pageIndex = 1, int pageSize = 20)
    {
        var pagedResult = _systemLogService.GetPagedSystemLogs(pageIndex, pageSize);
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        // _logger.LogInformation("{ipAddress} visited System logs page (page {pageIndex}, size {pageSize})", ipAddress, pageIndex, pageSize);
        return View(pagedResult);
    }

}
