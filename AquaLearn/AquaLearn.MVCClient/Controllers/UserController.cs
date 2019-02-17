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

         // HttpContext.Session.SetString("Username", user.Username);
          return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterStudent(User us)
        {
            us.RoleId = 2;
            
          if (UserHelper.SetUser(us))
          {   
            HttpContext.Session.SetString("Username", us.Username);
            HttpContext.Session.SetInt32("Classroom", us.ClassroomId);
            HttpContext.Session.SetInt32("Role", us.RoleId);
          
            return RedirectToAction("Index", "Home");
          }

          return RedirectToAction("Register", "User");
        }



        public IActionResult RegisterTeacher(User us,Classroom classname)
        {
            if (UserHelper.SetUser(us))
            {

                HttpContext.Session.SetString("Username", us.Username);
                HttpContext.Session.SetString("ClassroomName", classname.Name);



                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Register", "User");
        }



        public IActionResult Logout()
        {
          HttpContext.Session.Clear();
          return RedirectToAction("Index", "Home");
        }


    }
}