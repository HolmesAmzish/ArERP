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
}