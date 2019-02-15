﻿using System;
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
        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();
        //public static AquaLearnDbContext _dbn = new AquaLearnDbContext();

        private readonly MapperConfiguration userMap = new MapperConfiguration(mc =>
        {
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<User, adm.User>()
              .ForMember(m => m.UserId, u => u.MapFrom(s => s.UserId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        #region Get
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

        public static adm.User GetUserByUserName(string username)
        {
            return _db.User.FirstOrDefault(m => m.Username == username);
        }

        #endregion

        #region Set

        public static bool SetUser(adm.User user)
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

        public static bool SetUser2(adm.User user)
        {
            var newUser = new adm.User()
            {
                Username = user.Username,
                Password = user.Password
            };

            _db.User.Add(newUser);

            return _db.SaveChanges() == 1;
        }

        #endregion
    }
}
