using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class FishHelperTest
    {
        public FishHelper Sut { get; set; }
        public Fish Fish { get; set; }

        public FishHelperTest()
        {
            Sut = new FishHelper();

            Fish = new Fish()
            {
                
               


            };

        }

        [Fact]
        public void Test_GetFish2()
        {
            //Svar actual = Sut.GetFishes2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetFish()
        {
            var actual = Sut.GetFishes();

            Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}

