using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;
using System.ComponentModel.DataAnnotations;

namespace Factory.AddControllersWithViews
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;

        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Engineer> engineers = _db.Engineers.ToList();
            return View(engineers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Engineer engineer)
        {
        if (!ModelState.IsValid)
        { 
          ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
          return View(engineer);
        }
        else
        {
            _db.Engineers.Add(engineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
     
        public ActionResult Details(int id)
        {
            Engineer engineer = _db.Engineers
                                   .Include(model => model.EngineerMachines)
                                   .ThenInclude(join => join.Machine)
                                   .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(engineer);
        }

        public ActionResult Edit(int id)
        {
            Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(engineer);
        }

        [HttpPost]
        public ActionResult Edit(Engineer engineer)
        {
            _db.Engineers.Update(engineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(engineer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            _db.Engineers.Remove(engineer);
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
            return RedirectToAction("Details", new { id = engineer.EngineerId });
        }

          [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    }
}
