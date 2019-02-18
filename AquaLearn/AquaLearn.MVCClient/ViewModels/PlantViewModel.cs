using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ald = AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;

namespace AquaLearn.MVCClient.ViewModels
{
    public class PlantViewModel
    {
        public List<ald.Plant> GetPlants()
        {
            var helper = new PlantHelper();
            return helper.GetthePlants2();
        }
    }
}
