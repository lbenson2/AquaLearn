using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;
using AquaLearn.Data;

namespace AquaLearn.Tests.DataTests
{
    public class RoleHelperTest
    {
        public RoleHelper Sut { get; set; }
        public Role Role { get; set; }

        public RoleHelperTest()
        {
            Sut = new RoleHelper(new AquaLearnIMDbContext());

            Role = new Role()
            {
                Name="Teacher"




            };

        }

      

        [Fact]
        public void Test_GetRoles()
        {
            var db = Sut._idb;
            db.Role.Add(Role);
            db.SaveChanges();
            var actual = Sut.GetRoles();
           

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].RoleId == 1);
            Assert.True(actual[0].Name == "Teacher");
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
