using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class ExhibitHelper
    {
        private AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

        private MapperConfiguration exhibitMap = new MapperConfiguration(mc =>
        {
         
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Exhibit, adm.Exhibit>()
              .ForMember(m => m.ExhibitId, u => u.MapFrom(s => s.ExhibitId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.Exhibit> GetExhibits2()
        {
            var de = new List<adm.Exhibit>();

            foreach (var item in _db.Exhibit.ToList())
            {
                de.Add(new adm.Exhibit()
                {
                    ExhibitId = item.ExhibitId
                });
            }

            return de;
        }

        public List<adm.Exhibit> GetExhibits()
        {
            var exhibitList = new List<adm.Exhibit>();
            var mapper = exhibitMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Exhibit.ToList())
            {
                var u = mapper.Map<adm.Exhibit>(item);

                //u.Name = mapper2.Map<adm.Exhibit>(item);
                exhibitList.Add(u);
            }

            return exhibitList;
        }
    }
}