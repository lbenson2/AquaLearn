using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Fish
    {
        public int FishId { get; set; }
        public string Name { get; set; }
        public bool Schooling { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
        public int ExhibitId { get; set; }
        [NotMapped]
        public float[] Destination { get; private set; }
        [NotMapped]
        public float[] Vector3Current { get; set; }
    }
}
