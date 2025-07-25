using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.HumanResource.Controllers;

[Area("HumanResource")]
public class HomeController : Controller
{
    // GET: /HumanResource
    public IActionResult Index()
    {
        return View();
    }
}