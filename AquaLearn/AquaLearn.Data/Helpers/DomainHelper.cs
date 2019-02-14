using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;
//using admu = AquaLearn.Domain.Models.User;

namespace AquaLearn.Data.Helpers
{
    public static class DomainHelper
    {
        

        
     

        public static MapperConfiguration nameMapper = new MapperConfiguration(mc =>
        {

            mc.CreateMap<Role, adm.Role>();
            mc.CreateMap<User, adm.User>()
            //.ForPath(m => m.Username, u => u.MapFrom(src => src.User.Username))


        ;
        });
    }
}
