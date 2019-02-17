using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaLearn.Domain.Models;

namespace AquaLearn.MVCClient.Models
{
    public class ExhibitModel
    {
        public int ExhibitId { get; set; }
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public List<Fish> Fishes { get; set; }
        public List<Plant> Plants { get; set; }
        public List<Trash> Trash { get; set; }
    }
}
