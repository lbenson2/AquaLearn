using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AquaLearn.Domain.Models
{
    public class Exhibit
    {
        public int ExhibitId { get; set; }
        public string Name { get; set; }
        public WaterType WaterType { get; set; }
        public List<Fish> Fishes { get; set; }
        public List<Plant> Plants { get; set; }
        public List<Trash> Trash { get; set; }
        public List<Hazard> Hazard { get; set; }
        private Random rnd { get; }

        public Exhibit()
        {
            rnd = new Random();

            PopulateFishes();
            PopulatePlants();
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

        public void PopulatePlants()
        {
            Plants = new List<Plant>();

            // TODO: Add specific plants
            for (int i = 0; i < rnd.Next(3, 15); i++)
            {
                Plants.Add(new Plant());
            }
        }

        public float[] Moving(int i)
        {
            Fishes[i].Swim();

            return Fishes[i].Vector3Current;
        }

        public float[] PlaceStill(int i)
        {
            return Plants[i].Vector3Current;
        }

        public float[] PlaceMoving(int i)
        {
            return Fishes[i].Vector3Current;
        }
    }
}
