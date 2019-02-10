using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class WaterTypeTest
    {
        WaterType sut { get; set; }
        public WaterTypeTest()
        {
            sut = new WaterType()
            {
                Name =""
            };

        }

        [Fact]
        public void Test_WaterTypeProperties()
        {

            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.WaterTypeId);

        }
    }
}
