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
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;    
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
    {
      _userManager = userManager;
      _db = db; 
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Treat> treats = _db.Treats.ToList();
      return View(treats);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Treat treat = _db.Treats
        .Include(t => t.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(t => t.TreatId == id);
      return View(treat);
    }

    public ActionResult Edit(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      return View(treat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    public ActionResult Delete(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      return View(treat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    // not "Delete" because both `GET` and `POST` action methods for Delete take `id` as a param 
    {
      Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      _db.Treats.Remove(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(treat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      #nullable enable
      TreatFlavor? entity = _db.TreatFlavors.FirstOrDefault(join => 
        (join.FlavorId == flavorId && join.TreatId == treat.TreatId)
      );
      #nullable disable
      if (entity == null && flavorId != 0)
      {
        _db.TreatFlavors.Add(
          new TreatFlavor() { 
            FlavorId = flavorId, TreatId = treat.TreatId 
          }
        );
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      TreatFlavor entry = _db.TreatFlavors
        .FirstOrDefault(e => e.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(entry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}