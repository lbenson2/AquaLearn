using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaLearn.MVCClient.Models
{
    public class UserViewModel
    {
        public class User
        {
            public int UserId { get; set; }
            public Role UserRole { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int ClassroomId { get; set; }
            public List<Quiz> Quizzes { get; set; }

            public User()
            {
                UserRole = new Role();
                Username = string.Empty;
                Password = string.Empty;
                Quizzes = new List<Quiz>();
            }


        }
    }
}
