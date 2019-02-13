using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using dom = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class ExhibitHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration exhibitMap = new MapperConfiguration(mc =>
        {
         
            //mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Exhibit, dom.Exhibit>()
              .ForMember(m => m.ExhibitId, u => u.MapFrom(s => s.ExhibitId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<dom.Exhibit> GetExhibits()
        {
            var exhibitList = new List<dom.Exhibit>();
            var mapper = exhibitMap.CreateMapper();
            //var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Exhibit.ToList())
            {
                var u = mapper.Map<dom.Exhibit>(item);

                //u.Name = mapper2.Map<dom.Fish>(item);
                exhibitList.Add(u);
            }

            return exhibitList;
        }
    }
}