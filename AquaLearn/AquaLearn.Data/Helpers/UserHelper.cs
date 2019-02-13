using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers

{
    public class UserHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration userMap = new MapperConfiguration(mc =>
        {
          
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<User, adm.User>()
              .ForMember(m => m.UserId, u => u.MapFrom(s => s.UserId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.User> GetUsers()
        {
            var userList = new List<adm.User>();
            var mapper = userMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.User.ToList())
            {
                var u = mapper.Map<adm.User>(item);

                //u.Name = mapper2.Map<adm.Name>(item);
                userList.Add(u);
            }

            return userList;
        }
    }
}
