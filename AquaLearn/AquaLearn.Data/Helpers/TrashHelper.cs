using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class TrashHelper
    {
        private AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

        private MapperConfiguration trashMap = new MapperConfiguration(mc =>
        {
           
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Trash, adm.Trash>()
              .ForMember(m => m.TrashId, u => u.MapFrom(s => s.TrashId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.Trash> GetTrash2()
        {
            var dt = new List<adm.Trash>();

            foreach (var item in _db.Trash.ToList())
            {
                dt.Add(new adm.Trash()
                {
                    TrashId = item.TrashId
                });
            }

            return dt;
        }


        public List<adm.Trash> GetTrash()
        {
            var trashList = new List<adm.Trash>();
            var mapper = trashMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Trash.ToList())
            {
                var u = mapper.Map<adm.Trash>(item);

                //u.Name = mapper2.Map<adm.Fish>(item);
                trashList.Add(u);
            }

            return trashList;
        }
    }
}
