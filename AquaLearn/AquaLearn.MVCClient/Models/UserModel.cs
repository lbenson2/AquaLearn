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

        [Required]
        [MinLength(6, ErrorMessage = "Please make sure username is at lesat 5 characters")]
        [MaxLength(40, ErrorMessage = "This username is too long. Use less than 40 characters")]
        public string Username { get; set; }


        [Required]
        [MinLength(6, ErrorMessage = "Password is to short")]
        [MaxLength(50, ErrorMessage = "Password is to long")]

        public string Password { get; set; }

        public int ClassroomId { get; set; }

        public string Name { get; set; }

        public List<Quiz> Quizzes { get; set; }


       
    }
}
