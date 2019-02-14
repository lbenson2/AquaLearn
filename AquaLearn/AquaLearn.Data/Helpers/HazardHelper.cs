using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class HazardHelper
    {
        private AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

        private MapperConfiguration hazardMap = new MapperConfiguration(mc =>
        {
           
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Hazard, adm.Hazard>()
              .ForMember(m => m.HazardId, u => u.MapFrom(s => s.HazardId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.Hazard> GetHazards2()
        {
            var dh = new List<adm.Hazard>();

            foreach (var item in _db.Hazard.ToList())
            {
                dh.Add(new adm.Hazard()
                {
                    HazardId = item.HazardId
                });
            }

            return dh;
        }

        public List<adm.Hazard> GetHazards()
        {
            var hazardList = new List<adm.Hazard>();
            var mapper = hazardMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Hazard.ToList())
            {
                var u = mapper.Map<adm.Hazard>(item);

                //u.Name = mapper2.Map<adm.Fish>(item);
                hazardList.Add(u);
            }

            return hazardList;
        }
    }
}