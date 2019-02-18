using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;



namespace AquaLearn.Data.Helpers
{
    public class PlantHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public List<Plant> GetthePlants2()
        {
            return _db.Plant.Include(x => x.WaterType).ToList();
        }

        public PlantHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public PlantHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetPlant(Plant plant)
        {
            //if (_db != null)
            //{
            //    _db.Plant.Add(plant);
            //    return _db.SaveChanges();
            //}
            //else
            //{
                _idb.Plant.Add(plant);
                return _idb.SaveChanges();
            //}

        }



        public List<Plant> GetPlants()
        {
            //if (_db != null)
            //{
            //    var z = _db.Plant.ToList();
            //    return z;

            //}
            //else
            //{
                var y = _idb.Plant.ToList();
                return y;
            //}

        }
    }
}