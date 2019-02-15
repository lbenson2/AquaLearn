using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace AquaLearn.Data.Helpers
{
    public class ExhibitHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public ExhibitHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public ExhibitHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }



        public List<Exhibit> GetExhibits()
        {
            if (_db != null)
            {
                var z = _db.Exhibit.ToList();
                return z;

            }
            else
            {
                var y = _idb.Exhibit.ToList();
                return y;
            }

        }
    }
}
