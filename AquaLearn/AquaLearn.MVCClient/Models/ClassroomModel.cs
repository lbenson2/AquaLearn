using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaLearn.MVCClient.Models
{
    public class ClassroomModel
    {
        public int ClassroomId { get; set; }

        public string Name { get; set; }

        public int TeacherUserId { get; set; }
    }
}
