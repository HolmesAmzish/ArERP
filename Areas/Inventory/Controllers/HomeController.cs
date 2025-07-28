using ArERP.Areas.Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.Inventory.Controllers;

[Area("Inventory")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}