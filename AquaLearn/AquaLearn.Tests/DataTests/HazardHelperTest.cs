using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class HazardHelperTest
    {
        public HazardHelper Sut { get; set; }
        public Hazard Hazard { get; set; }

        public HazardHelperTest()
        {
            Sut = new HazardHelper();

            Hazard = new Hazard()
            {




            };

        }

        [Fact]
        public void Test_GetHazard2()
        {
            //var actual = Sut.GetHazards2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetHazard()
        {
            var actual = Sut.GetHazards();

            Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
