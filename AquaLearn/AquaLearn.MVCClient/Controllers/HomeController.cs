using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.MVCClient.Models;
using AquaLearn.MVCClient.ViewModels;

namespace AquaLearn.MVCClient.Controllers
{
 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Quiz()
        {
            var ex = new ExhibitModel();
            var fishVM = new FishViewModel();
            var plantVM = new PlantViewModel();
            var trashVM = new TrashViewModel();

            ex.Fishes = fishVM.GetFishes();
            ex.Plants = plantVM.GetPlants();
            ex.Trash = trashVM.GetTrash();
            return View("Quiz",ex);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
          return View("Login");
        }

        public IActionResult Register()
        {
          return View("Register");
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
          return PartialView(id);
        }
  }
}
