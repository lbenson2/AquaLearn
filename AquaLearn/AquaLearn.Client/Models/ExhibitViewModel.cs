using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaLearn.Domain.Models;

namespace AquaLearn.Client.Models
{
    public class ExhibitViewModel
    {
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public List<Fish> Fishes { get; set; }
        public List<Plant> Plants { get; set; }
        public List<Trash> Trash { get; set; }
        public List<Hazard> Hazard { get; set; }
        public float[] Vector3Current { get; set; }
        public float[] Vector3Destination { get; set; }
    }
}
