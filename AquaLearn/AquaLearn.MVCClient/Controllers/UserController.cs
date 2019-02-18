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
        public IActionResult Validation(User us)
        {
          var user = UserHelper.GetUserByUserName(us.Username);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (user.Password != us.Password)
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            
          return RedirectToAction("Index", "Home");
        }

        public IActionResult Register(User us)
        {
          if (UserHelper.SetUser(us))
          {
            var user = UserHelper.GetUsers().Where(u => u.Username == us.Username).FirstOrDefault();

            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
          }

          return RedirectToAction("Register", "Home");
        }

        public IActionResult Logout()
        {
          HttpContext.Session.Clear();
          return RedirectToAction("Index", "Home");
        }
    }
}