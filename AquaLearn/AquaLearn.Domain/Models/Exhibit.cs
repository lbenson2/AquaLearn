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
        private Random rnd { get; }

        public Exhibit()
        {
            Vector3Current = new float[] { 0, 0, 0 };
            Vector3Destination = new float[] { 0, 0, 0 };
            rnd = new Random();

            PopulateFishes();
        }

        public void PopulateFishes()
        {
            Fishes = new List<Fish>();

            // TODO: Add specific fish
            for (int i = 0; i < rnd.Next(3, 15); i++)
            {
                Fishes.Add(new Fish());
            }
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
            // TODO: get canvas width to be cap
            float x = rnd.Next(0, 720);
            // TODO: get canvas height to be cap
            float y = rnd.Next(0, 480);
            // Determine which layer the fish will swim on
            float z = rnd.Next(-15, -1);

            // Set the x, y, z values
            Vector3Current[0] = x;
            Vector3Current[1] = y;
            Vector3Current[2] = z;

            return Vector3Current;
        }
    }
}
