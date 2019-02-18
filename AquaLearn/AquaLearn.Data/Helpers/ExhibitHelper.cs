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


        public long SetExhibit(Exhibit exhibit)
        {
            
            
            
                _idb.Exhibit.Add(exhibit);
                return _idb.SaveChanges();
            

        }



        public List<Exhibit> GetExhibits()
        {
            
                var y = _idb.Exhibit.ToList();
                return y;
            

        }
    }
}
