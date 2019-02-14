using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class UserHelperTest
    {
        public UserHelper Sut { get; set; }
        public User User { get; set; }

        public UserHelperTest()
        {
            Sut = new UserHelper();

            User = new User()
            {
                UserId = 22,
                Username="Andy",
                Password="Andy",
                ClassroomId=22


                
            };

        }

        [Fact]
        public void Test_GetUsers2()
        {
           //var actual2 = Sut.GetUsers2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
           //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetUsers()
        {
            //var actual = Sut.GetUsers();

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
