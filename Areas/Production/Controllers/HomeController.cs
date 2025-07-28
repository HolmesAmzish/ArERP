using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.Production.Controllers;

[Area("Production")]
public class HomeController : Controller
{
    // GET: /Production/Index
    [HttpGet]
    public IActionResult Index() => View();
}