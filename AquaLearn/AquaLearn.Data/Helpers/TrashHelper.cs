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
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public TrashHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public TrashHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
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
