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
    public class FishHelperTest
    {
        public FishHelper Sut { get; set; }
        public Fish Fish { get; set; }

        public FishHelperTest()
        {
            Sut = new FishHelper(new AquaLearnIMDbContext());

            Fish = new Fish()
            {
                Name = "Shark",
                Schooling = false,
                Description="Sharks are the most threatening predators in the ocean."
            




            };

        }

       

        [Fact]
        public void Test_GetFishes()
        {
            var db = Sut._idb;
            db.Fish.Add(Fish);
            db.SaveChanges();
            var actual = Sut.GetFishes();

            Assert.NotNull(actual[0]);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].FishId == 1);
            Assert.True(actual[0].Name == "Shark");
            Assert.True(actual[0].Schooling == false);
            Assert.IsType<string>(actual[0].Description);
            // Assert.True(actual[0].Description == "Sharks are the most threatening predators in the ocean.");

        }
    }
}

