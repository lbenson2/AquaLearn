using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using dom = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class FishHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration fishMap = new MapperConfiguration(mc =>
        {
           
            //mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Fish, dom.Fish>()
              .ForMember(m => m.FishId, u => u.MapFrom(s => s.FishId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<dom.Fish> GetFishes()
        {
            var fishList = new List<dom.Fish>();
            var mapper = fishMap.CreateMapper();
            //var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Fish.ToList())
            {
                var u = mapper.Map<dom.Fish>(item);

                //u.Name = mapper2.Map<dom.Fish>(item);
                fishList.Add(u);
            }

            return fishList;
        }
    }
}
