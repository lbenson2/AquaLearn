using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class HazardTest
    {
        Hazard sut { get; set; } 
            public HazardTest()
        {
            sut = new Hazard()
            {
                Name =""
            };

        }

        [Fact]
        public void Test_HazardProperties()
        {
            
            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.HazardId);

        }
    }
}
