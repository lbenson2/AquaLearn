﻿using AquaLearn.Data.Helpers;
using System;
using ald= AquaLearn.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaLearn.MVCClient.ViewModels
{
    public class ClassroomViewModel
    {
        public static List<ald.Classroom> GetClassrooms()
        {
            return ClassroomHelper.GetClassroom();

        }


    }
}