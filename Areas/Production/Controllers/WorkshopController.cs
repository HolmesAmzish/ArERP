using ArERP.Areas.Production.Repository;
using ArERP.Areas.Production.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.Production.Controllers;

[Area("Production")]
public class WorkshopController : Controller
{
    private readonly IWorkshopService _workshopService;

    public WorkshopController(IWorkshopService workshopService)
    {
        this._workshopService = workshopService;
    }

    public IActionResult Index() => View(_workshopService.GetAllWorkshops());
}