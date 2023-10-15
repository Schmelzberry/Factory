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

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(machine);
    }

    public ActionResult Edit(int id)
    {
      Machine machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(machine);
    }
    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id)
    {
      Machine machine = _db.Machines
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(machine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(machine);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
        {
            Engineer engineer = _db.Engineers
                .FirstOrDefault(model => model.EngineerId == id);
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
            return View(engineer);
        }

        [HttpPost]
        public ActionResult AddMachine(Engineer engineer, int machineId)
        {
#nullable enable
            EngineerMachine? engineerMachine = _db.EngineerMachines
                .FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
#nullable disable
            if (engineerMachine == null && machineId != 0)
            {
                _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
                _db.SaveChanges();
            }
            return RedirectToAction("Show", new { id = engineer.EngineerId });
        }
  }
}