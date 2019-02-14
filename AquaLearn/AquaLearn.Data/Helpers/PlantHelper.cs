using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class PlantHelper
    {
        private AquaLearnIMDbContext _db = new AquaLearnIMDbContext();

        private MapperConfiguration plantMap = new MapperConfiguration(mc =>
        {
           
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Plant, adm.Plant>()
              .ForMember(m => m.PlantId, u => u.MapFrom(s => s.PlantId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<adm.Plant> GetPlants2()
        {
            var dp = new List<adm.Plant>();

            foreach (var item in _db.Plant.ToList())
            {
                dp.Add(new adm.Plant()
                {
                    PlantId = item.PlantId
                });
            }

            return dp;
        }

        public List<adm.Plant> GetPlants()
        {
            var plantList = new List<adm.Plant>();
            var mapper = plantMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Plant.ToList())
            {
                var u = mapper.Map<adm.Plant>(item);

               // u.Name = mapper2.Map<adm.Plant>(item);
                plantList.Add(u);
            }

            return plantList;
        }
    }
}