using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using dom = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class TrashHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration trashMap = new MapperConfiguration(mc =>
        {
           
            //mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Trash, dom.Trash>()
              .ForMember(m => m.TrashId, u => u.MapFrom(s => s.TrashId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<dom.Trash> GetTrash()
        {
            var trashList = new List<dom.Trash>();
            var mapper = trashMap.CreateMapper();
            //var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Trash.ToList())
            {
                var u = mapper.Map<dom.Trash>(item);

                //u.Name = mapper2.Map<dom.Fish>(item);
                trashList.Add(u);
            }

            return trashList;
        }
    }
}
