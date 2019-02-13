using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using dom = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class HazardHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration hazardMap = new MapperConfiguration(mc =>
        {
           
            //mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Hazard, dom.Hazard>()
              .ForMember(m => m.HazardId, u => u.MapFrom(s => s.HazardId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<dom.Hazard> GetHazards()
        {
            var hazardList = new List<dom.Hazard>();
            var mapper = hazardMap.CreateMapper();
            //var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Hazard.ToList())
            {
                var u = mapper.Map<dom.Hazard>(item);

                //u.Name = mapper2.Map<dom.Fish>(item);
                hazardList.Add(u);
            }

            return hazardList;
        }
    }
}