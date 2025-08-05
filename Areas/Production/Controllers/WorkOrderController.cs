using ArERP.Areas.Production.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.Production.Controllers;

[Area("Production")]
public class WorkOrderController : Controller
{
    private readonly IWorkOrderService _workOrderService;

    public WorkOrderController(IWorkOrderService workOrderService)
    {
        this._workOrderService = workOrderService;
    }

    public IActionResult Index() => View(_workOrderService.GetAllWorkOrders());

    [HttpGet] [Route("api/production/workorders")]
    public IActionResult GetAllWorkOrders() => Ok(_workOrderService.GetAllWorkOrders());

    // public IActionResult GetPagedWorkOrders([FromQuery] int pageIndex, [FromQuery] int pageSize) =>
    // Ok(_workOrderService.GetPagedWorkOrders(pageIndex, pageSize));
}