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
    public class UserHelperTest
    {
        public UserHelper Sut { get; set; }
        public User User { get; set; }

        public UserHelperTest()
        {
            Sut = new UserHelper(new AquaLearnIMDbContext());

            User = new User()
            {
                //UserId = 22,
                Username="Andy",
                Password="Andy",
                ClassroomId=22


                
            };

        }

        

        [Fact]
        public void Test_GetUsers()
        {
            var db = Sut._idb;
            db.User.Add(User);
            db.SaveChanges();
            var actual = Sut.GetUserTest();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].UserId == 1);
            //Assert.IsType<string>(actual[0].Description);
            //Assert.True(actual[0].Description == "Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe.");
            Assert.True(actual[0].Username == "Andy");
            Assert.True(actual[0].Password == "Andy");
            Assert.True(actual[0].ClassroomId == 22);

            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
