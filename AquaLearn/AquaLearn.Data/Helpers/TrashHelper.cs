using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public class TrashHelper
    {
        private AquaLearnDbContext _db { get; set; }
        private AquaLearnIMDbContext _idb { get; set; }


        public List<Trash> GettheTrash2()
        {
            return _db.Trash.Include(x => x.WaterType).ToList();
        }

        public TrashHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public TrashHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetTrash(Trash trash)
        {
            if (_db != null)
            {
                _db.Trash.Add(trash);
                return _db.SaveChanges();
            }
            else
            {
                _idb.Trash.Add(trash);
                return _idb.SaveChanges();
            }

        }
      
        public List<Trash> GetTrash()
        {
            if (_db != null)
            {
                var z = _db.Trash.ToList();
                return z;

            }
            else
            {
                var y = _idb.Trash.ToList();
                return y;
            }
        }
    }
}
