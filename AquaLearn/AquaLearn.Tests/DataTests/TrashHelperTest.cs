using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class TrashHelperTest
    {
        public TrashHelper Sut { get; set; }
        public Trash Trash { get; set; }

        public TrashHelperTest()
        {
            Sut = new TrashHelper();

            Trash = new Trash()
            {
                



            };

        }

        [Fact]
        public void Test_GetTrash2()
        {
            //var actual2 = Sut.GetTrash2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetTrash()
        {
            var actual = Sut.GetTrash();

            Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
