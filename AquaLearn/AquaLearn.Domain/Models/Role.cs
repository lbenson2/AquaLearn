using System;
using System.Collections.Generic;
using System.Text;


namespace AquaLearn.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public Role()
        {
            Name = "Student";
        }
    }
}