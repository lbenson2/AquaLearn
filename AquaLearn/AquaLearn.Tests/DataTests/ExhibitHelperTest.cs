using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaLearn.Data.Helpers;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.DataTests
{
    public class ExhibitHelperTest
    {
        public ExhibitHelper Sut { get; set; }
        public Exhibit Exhibit { get; set; }

        public ExhibitHelperTest()
        {
            Sut = new ExhibitHelper();

            Exhibit = new Exhibit()
            {
               ExhibitId=22,
               Name="Fish",




            };

        }

        [Fact]
        public void Test_GetExhibits()
        {
            var actual = Sut.GetExhibits();

            Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetExhibits2()
        {
            //var actual2 = Sut.GetExhibits2;

            //Assert.NotNull(actual);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual.Username == "Spkr");
        }
    }
}
