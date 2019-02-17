using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ald = AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;

namespace AquaLearn.MVCClient.ViewModels
{
    public class FishViewModel
    {
        public List<ald.Fish> GetFishes()
        {
            var helper = new FishHelper();
            return helper.GetFishes();
        }
    }
}
