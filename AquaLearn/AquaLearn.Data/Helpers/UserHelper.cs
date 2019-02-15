using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;
//using AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers

{
    public class UserHelper
    {


        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

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

        public static bool SetUser(adm.User user)
        {
            var newUser = new adm.User()
            {
                Username = user.Username,
                Password = user.Password
            };

            _db.User.Add(newUser);

            return _db.SaveChanges() == 1;
        }

        public AquaLearnDbContext _dbn { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public UserHelper()
        {
            _dbn = new AquaLearnDbContext();
        }

        public UserHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }



        public List<adm.User> GetUserTest()
        {
            if (_dbn != null)
            {
                var z = _dbn.User.ToList();
                return z;

            }
            else
            {
                var y = _idb.User.ToList();
                return y;
            }

        }


    }
}

