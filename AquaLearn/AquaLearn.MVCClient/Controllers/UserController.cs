using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.Domain.Models;
using Microsoft.AspNetCore.Http;
using mo = AquaLearn.MVCClient.Models;
using AquaLearn.MVCClient.ViewModels;
using AquaLearn.MVCClient.Models;
using Newtonsoft.Json;

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
          var user = UserViewModel.GetUserByUserName(us.Username);

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
            HttpContext.Session.SetString("Username", JsonConvert.SerializeObject(user));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterStudent(User us)
        {
            us.RoleId = 2;
            
          if (UserViewModel.SetUser(us))
          {   
            HttpContext.Session.SetString("Username", us.Username);
            HttpContext.Session.SetInt32("Classroom", us.ClassroomId);
            HttpContext.Session.SetInt32("Role", us.RoleId);
          
            return RedirectToAction("Index", "Home");
          }

          return RedirectToAction("Register", "User");
        }

        public IActionResult RegisterTeacher(mo.UserModel us)
        {
            us.RoleId = 1;

            var classroom = new Classroom()
            {
                Name = us.Name
            };

            if (ClassroomViewModel.SetClassroom(classroom))
            {
                classroom = ClassroomViewModel.GetClassroomByName(classroom.Name);

                var user = new User()
                {
                    Username = us.Username,
                    RoleId = us.RoleId,
                    Quizzes = us.Quizzes,
                    Password = us.Password,
                    ClassroomId = classroom.ClassroomId
                };

                if (UserViewModel.SetUser(user))
                {
                    HttpContext.Session.SetString("Username", us.Username);
                    HttpContext.Session.SetInt32("Classroom", us.ClassroomId);
                    HttpContext.Session.SetInt32("Role", us.RoleId);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Register", "Home");
                }
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
