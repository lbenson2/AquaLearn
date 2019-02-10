using System.Collections.Generic;

namespace AquaLearn.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

     

        public Role()
        {
            RoleId = 0;
            Name = "Student";
        }
    }
}