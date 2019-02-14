using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class RoleHelperTest
    {
        public RoleHelper Sut { get; set; }
        public Role Role { get; set; }

        public RoleHelperTest()
        {
            Sut = new RoleHelper();

            Role = new Role()
            {




            };

        }

        [Fact]
        public void Test_GetRole2()
        {
            //var actual2 = Sut.GetRoles2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetRoles()
        {
            var actual = Sut.GetRoles();

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
