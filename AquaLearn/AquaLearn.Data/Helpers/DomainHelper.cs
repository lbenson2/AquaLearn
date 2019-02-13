using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public static class DomainHelper
    {
        public static MapperConfiguration countryMapper = new MapperConfiguration(mc =>
        {
           
        });

        public static MapperConfiguration addressMapper = new MapperConfiguration(mc =>
        {
            mc.Mappers.Add(DomainHelper.countryMapper.GetMappers().FirstOrDefault());

          
        });
     

        public static MapperConfiguration nameMapper = new MapperConfiguration(mc =>
        {

            mc.CreateMap<Role, adm.Role>();
            mc.CreateMap<User, adm.User>()

        //.ForPath(m => m.Prefix.Name, u => u.MapFrom(src => src.Prefix))
        // .ForMember(m => m.First, u => u.MapFrom(src => src.First))
        // .ForMember(m => m.Last, u => u.MapFrom(src => src.Last));
        ;
        });
    }
}
