using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Fish
    {
        public string Name { get; set; }
        public bool Schooling { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
        public float[] Destination { get; private set; }
        public float[] Vector3Current { get; set; }
        private Random rnd { get; }

        public float[] SetDestination()
        {
            if (Destination != null)
            {
                // TODO: get canvas width to be cap
                float x = rnd.Next(0, 720);
                // TODO: get canvas height to be cap
                float y = rnd.Next(0, 480);
                // Determine which layer the fish will swim on
                float z = rnd.Next(-15, -1);

                // Set the x, y, z values
                Destination[0] = x;
                Destination[1] = y;
                Destination[2] = z;
            }
            else
            {
                Destination = new float[] { 0, 0, 0 };
                SetDestination();
            }

            return Destination;
        }

        public void Swim()
        {
            // Swim right
            if (Vector3Current[0] < Destination[0])
            {

            }

            // Swim left
            if (Vector3Current[0] > Destination[0])
            {

            }

            // Swim down
            if (Vector3Current[1] < Destination[1])
            {

            }

            // Swim up
            if (Vector3Current[1] > Destination[1])
            {

            }
        }
    }
}
