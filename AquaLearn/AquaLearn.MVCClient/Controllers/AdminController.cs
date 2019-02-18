using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using avm = AquaLearn.MVCClient.ViewModels;

namespace AquaLearn.MVCClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var user = avm.UserViewModel.GetUserByUserName(HttpContext.Session.GetString("Username"));
            return View(user);
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