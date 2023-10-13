using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.AddControllersWithViews
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> machines = _db.Machines.ToList();
      return View(machines);
    }

    public ActionResult Create()
    {
      return View();
    }
  }
}