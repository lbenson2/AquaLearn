using System;
using System.Collections.Generic;
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
        public float[] Destination { get; private set; }
        public float[] Vector3Current { get; set; }
        public Random rnd { get; set; }

        private float moveSpeed = 1f;

        public Fish()
        {
            rnd = new Random();
            Init();
        }

        public void Init()
        {
            // TODO: get canvas width to be cap
            float x = rnd.Next(0, 720);
            // TODO: get canvas height to be cap
            float y = rnd.Next(0, 480);
            // Determine which layer the fish will swim on
            float z = rnd.Next(-15, -1);

            Vector3Current = new float[] { 0, 0, 0 };
            // Set the x, y, z values
            Vector3Current[0] = x;
            Vector3Current[1] = y;
            Vector3Current[2] = z;
        }
    }
}
