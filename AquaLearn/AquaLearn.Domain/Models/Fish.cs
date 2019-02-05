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
        private Random rnd { get; set; }

        private int moveSpeed = 1;

        public Fish()
        {
            rnd = new Random();
            Init();
            SetDestination();
        }

        public float[] SetDestination()
        {
            if (Destination != null)
            {
                if (rnd == null)
                {
                    rnd = new Random();
                }
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

        public float[] Swim()
        {
            // Check if at/near destination before moving
            if (Destination == null)
            {
                SetDestination();
            }
            if (Vector3Current[0] > Destination[0] - 1
                || Vector3Current[0] < Destination[0] + 1)
            {
                if (Vector3Current[1] > Destination[1] - 1
                    || Vector3Current[1] < Destination[1] + 1)
                {
                    SetDestination();
                }
            }

            // Swim right
            if (Vector3Current[0] < Destination[0])
            {
                Vector3Current[0] += moveSpeed;
            }

            // Swim left
            if (Vector3Current[0] > Destination[0])
            {
                Vector3Current[0] -= moveSpeed;
            }

            // Swim down
            if (Vector3Current[1] < Destination[1])
            {
                Vector3Current[1] += moveSpeed;
            }

            // Swim up
            if (Vector3Current[1] > Destination[1])
            {
                Vector3Current[1] -= moveSpeed;
            }

            return Vector3Current;
        }

        public void Init()
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
        }
    }
}
