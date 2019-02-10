using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public Role UserRole { get; set; }

        public User()
        {
            UserId = 0;
            UserRole = new Role();
        }
    }
}
