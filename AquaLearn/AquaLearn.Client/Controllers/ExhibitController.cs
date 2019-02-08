using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AquaLearn.Client.Controllers
{
    public class ExhibitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
          return PartialView(id);
        }

        
    }
}