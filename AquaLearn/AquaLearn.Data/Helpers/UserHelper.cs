using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaLearn.Data.Helpers

{
    public class UserHelper
    {
        private static AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration userMap = new MapperConfiguration(mc =>
        {
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<User, adm.User>()
              .ForMember(m => m.UserId, u => u.MapFrom(s => s.UserId))
              .ForAllOtherMembers(m => m.Ignore());
        });


        public static List<adm.User> GetUsers()
        {
            var du = new List<adm.User>();

            foreach (var item in _db.User.ToList())
            {
                du.Add(new adm.User()
                {
                    UserId = item.UserId

                });
            }

            return du;
        }

        public List<adm.User> GetUsers2()
        {
            var userList = new List<adm.User>();
            var mapper = userMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.User.ToList())
            {
                var u = mapper.Map<adm.User>(item);

               // u.Username = mapper2.Map<adm.User.Username>(item);
                userList.Add(u);
            }

            return userList;
        }

        public static adm.User GetUserByUserName(string username)
        {
            return _db.User.FirstOrDefault(m => m.Username == username);
        }

        public bool SetUser(adm.User user)
        {
            var checkuser = GetUserByUserName(user.Username);

            if (checkuser != null && checkuser.Username == user.Username)
            {
                return false;
            }
            else
            {
               
                _db.User.Add(user);
                return _db.SaveChanges() > 0;
            }
        }



    }
}
