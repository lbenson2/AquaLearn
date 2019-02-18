using AquaLearn.Data.Helpers;
using ald = AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaLearn.MVCClient.ViewModels
{
    public static class AdminViewModel
    {
        public static List<ald.User> GetStudentsByClassroomId(int id)
        {
            return UserHelper.GetStudentsByClassroomId(id);
        }

    }
}
