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
        public static AquaLearnDbContext _dbb = new AquaLearnDbContext();
        private static AquaLearnDbContext _dbn { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

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
            return _dbb.User.FirstOrDefault(m => m.Username == username);
        }


        public static adm.Classroom GetUserByClassroomName(string classname)
        {
            return _dbb.Classroom.FirstOrDefault(m => m.Name == classname);
        }

        public static bool GetLogin(string username, string password)
        {
            var logged = GetUserByUserName(username);

            // user exists if not null
            if (logged != null)
            {
                // check password
                // password correct
                if (logged.Password == password)
                {
                    return true;
                }
                // password incorrect
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static List<adm.User> GetStudentsByClassroomId(int classroomId)
        {
            var allUsers = GetUsers();
            var studentsInClass = new List<adm.User>();

            foreach (var user in allUsers)
            {
                if (user.ClassroomId == classroomId
                    && user.RoleId != 1)
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
                _dbb.User.Add(user);
                return _dbb.SaveChanges() > 0;
            }
        }
      
        #endregion
    }
}
