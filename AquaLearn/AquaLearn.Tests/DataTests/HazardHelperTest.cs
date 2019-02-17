//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using AquaLearn.Data.Helpers;
//using AquaLearn.Domain.Models;
//using Xunit;
//using AquaLearn.Data;

//namespace AquaLearn.Tests.DataTests
//{
//    public class HazardHelperTest
//    {
//        public HazardHelper Sut { get; set; }
//        public Hazard Hazard { get; set; }

//        public HazardHelperTest()
//        {
//            Sut = new HazardHelper(new AquaLearnIMDbContext());

//            Hazard = new Hazard()
//            {
//                Name="Plastic",
//                Description="Pollution"





//            };

//        }

       

//        [Fact]
//        public void Test_GetHazards()
//        {
//            var db = Sut._idb;
//            db.Hazard.Add(Hazard);
//            db.SaveChanges();
//            var actual = Sut.GetHazards();

//            Assert.NotNull(actual);
//            Assert.True(actual.Count > 0);
//            Assert.True(actual[0].HazardId == 1);
//            Assert.True(actual[0].Description == "Pollution");
//            Assert.True(actual[0].Name == "Plastic");
//        }
//    }
//}
