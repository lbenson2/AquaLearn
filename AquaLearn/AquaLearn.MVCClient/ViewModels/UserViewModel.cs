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
    public static class UserViewModel
    {
        public static List<ald.User> GetUsers()
        {
            return UserHelper.GetUsers();
        }

        public static User GetUserByUserName(string username)
        {
           return UserHelper.GetUserByUserName(username);
        }

        public static bool LoginUser(string username,string password)
        {
            return UserHelper.GetLogin(username, password);
        }
     
        internal static bool SetUser(ald.User user)
        {
            return UserHelper.SetUser(user);
        }
    }
}
