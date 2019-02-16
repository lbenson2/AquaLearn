using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class HazardHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public HazardHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public HazardHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetHazard(Hazard hazard)
        {
            if (_db != null)
            {
                _db.Hazard.Add(hazard);
                return _db.SaveChanges();
            }
            else
            {
                _idb.Hazard.Add(hazard);
                return _idb.SaveChanges();
            }

        }



        public List<Hazard> GetHazards()
        {
            if (_db != null)
            {
                var z = _db.Hazard.ToList();
                return z;

            }
            else
            {
                var y = _idb.Hazard.ToList();
                return y;
            }

        }
    }
}