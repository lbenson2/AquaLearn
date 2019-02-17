using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquaLearn.MVCClient.Models;
using AquaLearn.MVCClient.ViewModels;

namespace AquaLearn.MVCClient.Controllers
{
    public class ExhibitController : Controller
    {
        public IActionResult Index()
        {
            var ex = new ExhibitModel();
            var fishVM = new FishViewModel();
            var plantVM = new PlantViewModel();
            var trashVM = new TrashViewModel();

            ex.Fishes = fishVM.GetFishes();
            ex.Plants = plantVM.GetPlants();
            ex.Trash = trashVM.GetTrash();

            return View(ex);
        }
    }
}