using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClassroomId { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public User()
        { 
            Username = string.Empty;
            Password = string.Empty;
            Quizzes = new List<Quiz>();
        }

       
    }
}
