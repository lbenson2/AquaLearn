using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
   public  class Classroom
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }

        public Classroom()
        {
            Name = "ClassroomName";
        }

    }
}
