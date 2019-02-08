using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aldm = AquaLearn.Domain.Models;

namespace AquaLearn.Client.Models
{
    public class PlantViewModel
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public aldm.WaterType WaterType { get; set; }
        public string Description { get; set; }
        public float[] Vector3Current { get; set; }
        private Random rnd { get; set; }
    }
}
