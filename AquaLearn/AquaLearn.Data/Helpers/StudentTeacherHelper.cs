//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using AutoMapper;
//using AquaLearn.Data.Entities;
//using adm = AquaLearn.Domain.Models;

//namespace AquaLearn.Data.Helpers
//{
//    public class StudentTeacherHelper
//    {
//        private AquaLearnDbContext _db = new AquaLearnDbContext();

//        private MapperConfiguration studentMap = new MapperConfiguration(mc =>
//        {
//            mc.Mappers.Add(DomainHelper.addressMapper.GetMappers().FirstOrDefault());
//            mc.Mappers.Add(DomainHelper.countryMapper.GetMappers().FirstOrDefault());
//            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

//            mc.CreateMap<Student, adm.Student>()
//              .ForMember(m => m.StudentId, u => u.MapFrom(s => s.StudentId))
//              .ForAllOtherMembers(m => m.Ignore());
//        });

//        public List<adm.Student> GetStudents()
//        {
//            var studentList = new List<adm.Student>();
//            var mapper = studentMap.CreateMapper();
//            var mapper2 = DomainHelper.nameMapper.CreateMapper();

//            foreach (var item in _db.Student.ToList())
//            {
//                var u = mapper.Map<adm.Student>(item);

//                //u.Name = mapper2.Map<adm.Name>(item);
//                studentList.Add(u);
//            }

//            return studentList;
//        }
//    }
//}