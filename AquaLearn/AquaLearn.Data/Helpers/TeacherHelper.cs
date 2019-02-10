//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using AutoMapper;
//using AquaLearn.Data.Entities;
//using adm = AquaLearn.Domain.Models;

//namespace AquaLearn.Data.Helpers
//{
//    public class TeacherHelper
//    {
//        private AquaLearnDbContext _db = new AquaLearnDbContext();

//        private MapperConfiguration teacherMap = new MapperConfiguration(mc =>
//        {
//            mc.Mappers.Add(DomainHelper.addressMapper.GetMappers().FirstOrDefault());
//            mc.Mappers.Add(DomainHelper.countryMapper.GetMappers().FirstOrDefault());
//            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

//            mc.CreateMap<Teacher, adm.Teacher>()
//              .ForMember(m => m.TeacherId, u => u.MapFrom(s => s.TeacherId))
//              .ForAllOtherMembers(m => m.Ignore());
//        });

//        public List<adm.Teacher> GetTeachers()
//        {
//            var teacherList = new List<adm.Teacher>();
//            var mapper = teacherMap.CreateMapper();
//            var mapper2 = DomainHelper.nameMapper.CreateMapper();

//            foreach (var item in _db.Teacher.ToList())
//            {
//                var u = mapper.Map<adm.Teacher>(item);

//                //u.Name = mapper2.Map<adm.Name>(item);
//                teacherList.Add(u);
//            }

//            return teacherList;
//        }
//    }
//}