using System.Collections.Generic;
using System.Linq;
using AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public class WaterTypeFinalHelper
    {
        private AquaLearnDbContext _db { get; set; }
        private AquaLearnIMDbContext _idb { get; set; }

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
