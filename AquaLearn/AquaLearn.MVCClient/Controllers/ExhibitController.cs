using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.MVCClient.Models;

namespace AquaLearn.MVCClient.Controllers
{
    public class ExhibitController : Controller
    {
        public IActionResult Index()
        {
            var i = new ExhibitViewModel();
            i.ExhibitId = 0;
            return View(i);
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
          return PartialView(id);
        }

        public IActionResult SetDeep()
        {
          var i = new ExhibitViewModel();
          i.ExhibitId = 0;
          return View(i);
        }

        public IActionResult SetCoral()
        {
          var i = new ExhibitViewModel();
          i.ExhibitId = 1;
          return View(i);
        }

    
  }
}