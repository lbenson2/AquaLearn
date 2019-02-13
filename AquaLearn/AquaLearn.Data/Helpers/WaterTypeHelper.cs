using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class WaterTypeHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration watertypeMap = new MapperConfiguration(mc =>
        {
           
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<WaterType, adm.WaterType>()
              .ForMember(m => m.WaterTypeId, u => u.MapFrom(s => s.WaterTypeId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.WaterType> GetWaterTypes()
        {
            var watertypeList = new List<adm.WaterType>();
            var mapper = watertypeMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.WaterType.ToList())
            {
                var u = mapper.Map<adm.WaterType>(item);

                //u.Name = mapper2.Map<adm.WaterType>(item);
                watertypeList.Add(u);
            }

            return watertypeList;
        }
    }
}

