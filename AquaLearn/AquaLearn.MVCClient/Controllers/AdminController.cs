using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using avm = AquaLearn.MVCClient.ViewModels;
using AquaLearn.MVCClient.Models;
using AquaLearn.Domain.Models;

namespace AquaLearn.MVCClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var user = avm.UserViewModel.GetUserByUserName(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("Username")).Username);
            var Classrooms = avm.ClassroomViewModel.GetClassrooms();
            var Classroom = "";
            for (var i = 0; i < Classrooms.Count; i++)
            {
                if (user.ClassroomId == Classrooms[i].ClassroomId)
                {
                    Classroom = Classrooms[i].Name;
                }
            }
            var StudentList = avm.AdminViewModel.GetStudentsByClassroomId(user.ClassroomId);
            var userModel = new UserModel()
            {
                Username = user.Username,
                UserId = user.UserId,
                ClassroomId = user.ClassroomId,
                RoleId = user.RoleId,
                ClassroomName = Classroom,
                Students = StudentList
        };
            return View(userModel);
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id, UserModel user)
        {
            return PartialView(id, user);
        }
    }
}