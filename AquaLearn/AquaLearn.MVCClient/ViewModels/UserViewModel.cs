using ald= AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;

namespace AquaLearn.MVCClient.Models
{
    public class UserViewModel

    {
        public List<ald.User> GetUsers()
        {
            return UserHelper.GetUsers();
        }

        public static User GetUserByUserName(string username)
        {
           return UserHelper.GetUserByUserName(username);
        }

        internal bool Register(Role role, string username, string password,Classroom classroom)
        {
            var usr = new ald.User()
            {

                UserRole = role,
                Username = username,
                Password = password,
                ClassroomId = classroom.ClassroomId
            };

            return UserHelper.SetUser(usr);
        }

    }
}
