using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;    
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
    {
      _userManager = userManager;
      _db = db; 
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Flavor> flavors = _db.Flavors.ToList();
      return View(flavors);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      if (!ModelState.IsValid)
      {
        return View(flavor);
      }
      else {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        flavor.User = user;
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = flavor.FlavorId });
      }
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Flavor flavor = _db.Flavors
        .Include(f => f.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(f => f.FlavorId == id);
      return View(flavor);
    }

    public ActionResult Edit(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      return View(flavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    public ActionResult Delete(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      return View(flavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      _db.Flavors.Remove(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(flavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      TreatFlavor? entity = _db.TreatFlavors.FirstOrDefault(join => 
        (join.TreatId == treatId && join.FlavorId == flavor.FlavorId)
      );
      #nullable disable
      if (entity == null && treatId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int id)
    {
      TreatFlavor entry = _db.TreatFlavors
        .FirstOrDefault(e => e.TreatFlavorId == id);
      _db.TreatFlavors.Remove(entry);
      _db.SaveChanges();
      return RedirectToAction("Index", "Flavors");
    }
  }
}