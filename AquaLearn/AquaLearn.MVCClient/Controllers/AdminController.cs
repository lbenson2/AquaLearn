using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AquaLearn.MVCClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetStudents(int id)
        {
            return RedirectToAction("Index","Admin");
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
            return PartialView(id);
        }


    }
}