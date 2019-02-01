using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Hazard
    {
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
    }
}
