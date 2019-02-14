using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class PlantHelperTest
    {
        public PlantHelper Sut { get; set; }
        public Plant Plant { get; set; }

        public PlantHelperTest()
        {
            Sut = new PlantHelper();

            Plant = new Plant()
            {




            };

        }

        [Fact]
        public void Test_GetPlants2()
        {
            //var actual = Sut.GetPlants2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetPlants()
        {
            var actual = Sut.GetPlants();

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
