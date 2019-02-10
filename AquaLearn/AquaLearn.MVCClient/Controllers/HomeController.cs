﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.MVCClient.Models;

namespace AquaLearn.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult LoginTeacher()
        //{
        //  var user = new User();
        //  return View(user);
        //}

        //public IActionResult LoginStudent()
        //{
        //  var user = new User();
        //  return View(user);
        //}

        public IActionResult Login()
        {
          return View("Login");
        }
  }
}