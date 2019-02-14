using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public class RoleHelper
    {
        private AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

        private MapperConfiguration roleMap = new MapperConfiguration(mc =>
        {
           
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Role, adm.Role>()
              .ForMember(m => m.RoleId, u => u.MapFrom(s => s.RoleId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.Role> GetRoles2()
        {
            var dr = new List<adm.Role>();

            foreach (var item in _db.Role.ToList())
            {
                dr.Add(new adm.Role()
                {
                    RoleId = item.RoleId
                });
            }

            return dr;
        }

        public List<adm.Role> GetRoles()
        {
            var roleList = new List<adm.Role>();
            var mapper = roleMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Role.ToList())
            {
                var u = mapper.Map<adm.Role>(item);

                //u.Name = mapper2.Map<adm.Role>(item);
                roleList.Add(u);
            }

            return roleList;
        }
    }
}