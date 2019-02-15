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
        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();
        public static AquaLearnDbContext _dbn = new AquaLearnDbContext();

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

        public List<adm.User> GetUserTest()
        {
            if (_dbn != null)
            {
                var z = _dbn.User.ToList();
                return z;
            }
            else
            {
                var y = _db.User.ToList();
                return y;
            }
        }

        public static adm.User GetUserByUserName(string username)
        {
            return _db.User.FirstOrDefault(m => m.Username == username);
        }

        public List<adm.User> GetStudentByClassroomId(int classroomId)
        {
            var allUsers = GetUsers();
            var studentsInClass = new List<adm.User>();

            foreach (var user in allUsers)
            {
                if (user.ClassroomId == classroomId
                    && user.UserRole.RoleId != 1)
                {
                    studentsInClass.Add(user);
                }
            }

            return studentsInClass;
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
      
        #endregion
    }
}
