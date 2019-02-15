using ald= AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AquaLearn.Domain.Models;

namespace AquaLearn.MVCClient.Models
{
    public class UserModel
    {
        [Required]
        public int UserId { get; set; }

        public List<ald.User> Students { get; set; }

        
        public Role UserRole { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClassroomId { get; set; }
        public List<Quiz> Quizzes { get; set; }
    }
}
