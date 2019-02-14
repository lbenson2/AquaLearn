using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class WaterTypeFinalHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public WaterTypeFinalHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public WaterTypeFinalHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

       

        public List<WaterType> GetWaterTypesFinal()
        {
            if (_db != null)
            {
                var z=_db.WaterType.ToList();
                return z;
                
            }
            else
            {
                var y=_idb.WaterType.ToList();
                return y;
            }

        }
    }
}
