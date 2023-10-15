using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;
using System.ComponentModel.DataAnnotations;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
      private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    { 
#nullable enable
      Engineer[]? e = _db.Engineers.ToArray();
#nullable disable
      Machine[] m = _db.Machines.ToArray();
      
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("engineers", e);
      model.Add("machines", m);
      return View(model);
    }
  }
}