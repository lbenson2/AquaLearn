using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aldm = AquaLearn.Domain.Models;

namespace AquaLearn.MVCClient.Models
{
    public class FishViewModel
    {
        public int FishId { get; set; }
        public string Name { get; set; }
        public bool Schooling { get; set; }
        public aldm.WaterType WaterType { get; set; }
        public string Description { get; set; }
        public float[] Destination { get; set; }
        public float[] Vector3Current { get; set; }
        public Random rnd { get; set; }
        public float MoveSpeed { get; set; }
    }
}
