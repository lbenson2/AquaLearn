using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AquaLearn.Domain.Models
{
    public class Exhibit
    {
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public List<Fish> Fishes { get; set; }
        public List<Plant> Plants { get; set; }
        public List<Trash> Trash { get; set; }
        public List<Hazard> Hazard { get; set; }
        public float[] Vector3Current { get; set; }
        public float[] Vector3Destination { get; set; }

        public Exhibit()
        {
            Vector3Current = new float[] { 0, 0, 0 };
            Vector3Destination = new float[] { 0, 0, 0 };
        }

        public float[] Moving()
        {
            return Vector3Current;
        }

        public float[] PlaceStill()
        {
            return Vector3Current;
        }

        public float[] PlaceMoving()
        {
            return Vector3Current;
        }
    }
}
