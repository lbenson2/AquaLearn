using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.Client.Models;

namespace AquaLearn.Client.Controllers
{
    public class ExhibitController : Controller
    {
        public IActionResult Index()
        {
            var i = new ExhibitViewModel();
            return View(i);
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
          return PartialView(id);
        }

        
    }
}