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
    public class WaterTypeHelperTest
    {
        public WaterTypeFinalHelper Sut { get; set; }
        public WaterType WaterType { get; set; }

        public WaterTypeHelperTest()
        {
            Sut = new WaterTypeFinalHelper(new AquaLearnIMDbContext());

            WaterType = new WaterType()
            {
                //WaterTypeId = 22,
                Name = "Ocean Salt Water"
                



            };

        }
        [Fact]
        public void Test_GetWaterTypes()
        {
            //var actual = Sut.GetWaterTypes();

            //Assert.NotNull(actual[0]);
            //Assert.True(actual.Count > 0);
            //Assert.NotNull(actual[0].WaterTypeId == 4);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetWaterTypes2()
        {
           //var actual2 = Sut.GetWaterTypes2();

            //Assert.NotNull(actual2[0]);
            //Assert.True(actual2.Count > 0);
            //Assert.NotNull(actual2[0].WaterTypeId == 4);
            //Assert.NotNull(actual.Username == "Spkr");
        }

        [Fact]
        public void Test_GetWaterTypesFinal()
        {
            var db = Sut._idb;
            db.WaterType.Add(WaterType);
            db.SaveChanges();
            var actual3 = Sut.GetWaterTypesFinal();

           Assert.NotNull(actual3[0]);
           Assert.True(actual3.Count > 0);
           Assert.True(actual3[0].WaterTypeId == 1);
            Assert.True(actual3[0].Name == "Ocean Salt Water");
            
        }


       

        //[Fact]
        //public void Test_IsValid()
        //{
        //  Assert.True(Sut.IsValid());
        //}
    }
}
