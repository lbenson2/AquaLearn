using AquaLearn.Data.Helpers;
using System;
using ald= AquaLearn.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaLearn.MVCClient.ViewModels
{
    public static class ClassroomViewModel
    {
        public static List<ald.Classroom> GetClassrooms()
        {
            return ClassroomHelper.GetClassroom();
        }

        public static bool SetClassroom(ald.Classroom classname)
        {
            return ClassroomHelper.SetClassroom(classname);
        }

        public static ald.Classroom GetClassroomByName(string name)
        {
            return ClassroomHelper.GetClassroomByName(name);
        }
    }
}
