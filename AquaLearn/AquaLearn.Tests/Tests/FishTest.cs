using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class FishTest
    {
        Fish sut { get; set; }
        public FishTest()
        {
            sut = new Fish()
            {
                Name = "",
                Description=""
            };

        }

        [Fact]
        public void Test_FishProperties()
        {
            //Assert.IsType<WaterType>(sut.WaterType);
            Assert.IsType<string>(sut.Name);
            Assert.IsType<string>(sut.Description);
            Assert.IsType<bool>(sut.Schooling);
            Assert.IsType<int>(sut.FishId);

        }



    }

}
