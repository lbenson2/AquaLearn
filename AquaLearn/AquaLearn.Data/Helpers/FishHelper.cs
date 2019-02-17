using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaLearn.Data.Helpers
{
    public class FishHelper
    {
        private static AquaLearnDbContext _db = new AquaLearnDbContext();

        public static List<adm.Fish> GettheFishes()
        {
            var df = new List<adm.Fish>();

            foreach (var item in _db.Fish.ToList())
            {
                df.Add(new adm.Fish()
                {
                    Name = item.Name

                });
            }
            return df;
        }

        public List<adm.Fish> GettheFishes2()
        {
            return _dbn.Fish.Include(x => x.WaterType).ToList();
        }

        public AquaLearnDbContext _dbn { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public FishHelper()
        {
            _dbn = new AquaLearnDbContext();
        }

        public FishHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetFish(adm.Fish fish)
        {
            if (_dbn != null)
            {
                _dbn.Fish.Add(fish);
                return _dbn.SaveChanges();
            }
            else
            {
                _idb.Fish.Add(fish);
                return _idb.SaveChanges();
            }

        }



        public List<adm.Fish> GetFishes()
        {
            if (_dbn != null)
            {
                var z = _dbn.Fish.ToList();
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
