using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Data.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        //public Role UserRole { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClassroomId { get; set; }
    }
}

