using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class PlantTest
    {
        Plant sut { get; set; }
        public PlantTest()
        {
            sut = new Plant()
            {
                Name =""
            };

        }

        [Fact]
        public void Test_PlantProperties()
        {

            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.PlantId);

        }
    }
}
