using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public float[] Vector3Current { get; set; }
        private Random rnd { get; set; }

        public Plant()
        {
            rnd = new Random();
            Init();
        }

        private void Init()
        {
            // TODO: get canvas width to be cap
            float x = rnd.Next(0, 720);
            // TODO: get 10% of the canvas height to be cap
            int canvasHeight = 480;
            int placementArea = (int)(canvasHeight * 0.9f);
            float y = rnd.Next(placementArea, canvasHeight);
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
