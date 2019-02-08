using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aldm = AquaLearn.Domain.Models;
using AquaLearn.Client.Models;

namespace AquaLearn.Client.Models
{
    public class ExhibitViewModel
    {
        public int ExhibitId { get; set; }
        public string Name { get; set; }
        public aldm.WaterType WaterType { get; set; }
        public List<FishViewModel> Fishes { get; set; }
        public List<PlantViewModel> Plants { get; set; }
        public List<aldm.Trash> Trash { get; set; }
        public List<aldm.Hazard> Hazard { get; set; }
    }
}
