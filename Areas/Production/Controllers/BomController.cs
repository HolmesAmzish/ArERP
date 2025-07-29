using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.Production.Controllers;

[Area("Production")]
public class BomController : Controller
{
    private readonly IBomService _bomService;

    public BomController(IBomService bomService)
    {
        _bomService = bomService;
    }

    // GET: /Production/Bom/Index
    public IActionResult Index()
    {
        var boms = _bomService.GetAllBoms();
        return View(boms);
    }

    
    // GET: /Production/Bom/Details/{id}
    public IActionResult Details(int id)
    {
        var bom = _bomService.GetBomById(id);
        if (bom == null)
        {
            return NotFound();
        }
        return View(bom);
    }

    // GET: /Production/Bom/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Production/Bom/Create
    [HttpPost] [ValidateAntiForgeryToken]
    public IActionResult Create(Bom bom)
    {
        if (!ModelState.IsValid)
        {
            return View(bom);
        }
        _bomService.CreateBom(bom);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var bom = _bomService.GetBomById(id);
        if (bom == null)
        {
            return NotFound();
        }
        return View(bom);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Bom bom)
    {
        if (id != bom.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _bomService.UpdateBom(bom);
            return RedirectToAction(nameof(Index));
        }
        return View(bom);
    }

    public IActionResult Delete(int id)
    {
        var bom = _bomService.GetBomById(id);
        if (bom == null)
        {
            return NotFound();
        }
        return View(bom);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _bomService.DeleteBom(id);
        return RedirectToAction(nameof(Index));
    }
}
