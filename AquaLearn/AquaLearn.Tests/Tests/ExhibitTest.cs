using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class ExhibitTest
    {
        Exhibit sut { get; set; }
        public ExhibitTest()
        {
            sut = new Exhibit()
            {
                Name = "",
                WaterType = new WaterType(),
                Fishes = new List<Fish>(),
                Trash = new List<Trash>(),
                Hazard = new List<Hazard>(),
                //Vector3Current = new float[],
                //Vector3Current = new float[],

            };


        }
        [Fact]
        public void Test_ExhibitProperties()
        {
            Assert.IsType<WaterType>(sut.WaterType);
            Assert.IsType<string>(sut.Name);
            Assert.IsType<List<Fish>>(sut.Fishes);
            Assert.IsType<int>(sut.ExhibitId);
            Assert.IsType<List<Plant>>(sut.Plants);
            Assert.IsType<List<Trash>>(sut.Trash);
            Assert.IsType<List<Hazard>>(sut.Hazard);
            //Assert.IsType<float[]>(sut.Vector3Current);
            //Assert.IsType<float>(sut.Vector3Destination);


        }
    }
}
