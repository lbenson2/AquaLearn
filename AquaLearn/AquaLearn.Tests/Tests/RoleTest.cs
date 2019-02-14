using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class RoleTest
    {
        Role sut { get; set; }
        public RoleTest()
        {
            sut = new Role()
            {

            };
        }

        [Fact]
        public void Test_RoleProperties()
        {
            
            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.RoleId);
            
        }
    }
}
