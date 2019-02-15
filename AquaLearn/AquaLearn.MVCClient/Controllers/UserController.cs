using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;
using Microsoft.AspNetCore.Http;

namespace AquaLearn.MVCClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoginTeacher()
        {
          var user = new User();
          return View(user);
        }

        public IActionResult LoginStudent()
        {
          var user = new User();
          return View(user);
        }

        public IActionResult Validation(User us)
        {
          var user = UserHelper.GetUsers().Where(u => u.Username == us.Username).FirstOrDefault();

          if (user == null)
          {
            RedirectToAction("../Home/Login");
          }

          if (user.Password != us.Password)
          {
            RedirectToAction("../Home/Login");
          }

          HttpContext.Session.SetInt32("UserId", user.UserId);
          HttpContext.Session.SetString("Username", user.Username);
          return View("../Home/Index");
        }

        public IActionResult Post(User us)
        {
          if (UserHelper.SetUser(us))
          {
            var user = UserHelper.GetUsers().Where(u => u.Username == us.Username).FirstOrDefault();
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("Username", user.Username);
            return View("../Home/Index");
          }

          return View("../Home/Register");
        }

        public IActionResult Logout()
        {
          HttpContext.Session.Clear();
          return RedirectToAction("Index", "Home");
        }
    }
}