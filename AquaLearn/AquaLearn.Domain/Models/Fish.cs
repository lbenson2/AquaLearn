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
        private float[] schoolingVector3 { get; set; }

        public Fish()
        {
            rnd = new Random();
            Init();
        }

        public void Init()
        {
            // GET FISH TO INIT

            int schooling = rnd.Next(0, 2);
            if (schooling == 0)
            {
                Schooling = false;
                Vector3Current = SetVector3();
            }
            else
            {
                Schooling = true;
                if (schoolingVector3 == null)
                {
                    Vector3Current = SetVector3();
                    schoolingVector3 = Vector3Current;
                }
                else
                {
                    Vector3Current = schoolingVector3;
                }
            }
        }

        private float[] SetVector3()
        {
            float[] vector3 = new float[] { 0, 0, 0 };
            // TODO: get canvas width to be cap
            float x = rnd.Next(0, 720);
            // TODO: get canvas height to be cap
            float y = rnd.Next(0, 480);
            // Determine which layer the fish will swim on
            float z = rnd.Next(-15, -1);

            // Set the x, y, z values
            vector3[0] = x;
            vector3[1] = y;
            vector3[2] = z;

            return vector3;
        }
    }
}
