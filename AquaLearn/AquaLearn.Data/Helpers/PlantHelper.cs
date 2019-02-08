using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using dom = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class PlantHelper
    {
        private AquaLearnDbContext _db = new AquaLearnDbContext();

        private MapperConfiguration plantMap = new MapperConfiguration(mc =>
        {
            //mc.Mappers.Add(DomainHelper.addressMapper.GetMappers().FirstOrDefault());
            //mc.Mappers.Add(DomainHelper.countryMapper.GetMappers().FirstOrDefault());
            //mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Plant, dom.Plant>()
              .ForMember(m => m.PlantId, u => u.MapFrom(s => s.PlantId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        public List<dom.Plant> GetPlants()
        {
            var plantList = new List<dom.Plant>();
            var mapper = plantMap.CreateMapper();
            //var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.Plant.ToList())
            {
                var u = mapper.Map<dom.Plant>(item);

                //u.Name = mapper2.Map<dom.Fish>(item);
                plantList.Add(u);
            }

            return plantList;
        }
    }
}