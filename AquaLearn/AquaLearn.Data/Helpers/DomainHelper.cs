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
           // mc.CreateMap<Address, adm.Country>()
           //   .ForMember(m => m.Name, u => u.MapFrom(src => src.Country))
            //  .ForMember(m => m.Code, u => u.NullSubstitute("US"));
        });

        public static MapperConfiguration addressMapper = new MapperConfiguration(mc =>
        {
            mc.Mappers.Add(DomainHelper.countryMapper.GetMappers().FirstOrDefault());

           // mc.CreateMap<Address, adm.Address>()
            //  .ForMember(m => m.Id, u => u.MapFrom(src => src.AddressId));
        });
     

        public static MapperConfiguration nameMapper = new MapperConfiguration(mc =>
        {
            //mc.CreateMap<Student, adm.Student>();
            //mc.CreateMap<Teacher, adm.Teacher>();
            mc.CreateMap<Role, adm.Role>()
        //.ForPath(m => m.Prefix.Name, u => u.MapFrom(src => src.Prefix))
        // .ForMember(m => m.First, u => u.MapFrom(src => src.First))
        // .ForMember(m => m.Last, u => u.MapFrom(src => src.Last));
        ;
        });
    }
}
