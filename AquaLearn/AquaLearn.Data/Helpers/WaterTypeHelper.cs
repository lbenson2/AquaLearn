using System.Collections.Generic;
using System.Linq;
using adm = AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public class WaterTypeHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        public List<adm.WaterType> GetWaterTypes2()
        {
            var dwt = new List<adm.WaterType>();

            foreach (var item in _db.WaterType.ToList())
            {
                dwt.Add(new adm.WaterType()
                {
                    WaterTypeId = item.WaterTypeId,
                    Name=item.Name
                });
            }

            return dwt;
        }
    }
}

