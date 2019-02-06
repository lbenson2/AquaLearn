using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Hazard
    {
        public int HazardID { get; set; }
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
    }
}
