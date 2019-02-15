using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class FishHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public FishHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public FishHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetFish(Fish fish)
        {
            if (_db != null)
            {
                _db.Fish.Add(fish);
                return _db.SaveChanges();
            }
            else
            {
                _idb.Fish.Add(fish);
                return _idb.SaveChanges();
            }

        }



        public List<Fish> GetFishes()
        {
            if (_db != null)
            {
                var z = _db.Fish.ToList();
                return z;

            }
            else
            {
                var y = _idb.Fish.ToList();
                return y;
            }

        }
    }
}
