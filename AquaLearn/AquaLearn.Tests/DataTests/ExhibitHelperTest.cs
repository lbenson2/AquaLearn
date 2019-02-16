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
//    public class ExhibitHelperTest
//    {
//        public ExhibitHelper Sut { get; set; }
//        public Exhibit Exhibit { get; set; }

//        public ExhibitHelperTest()
//        {
//            Sut = new ExhibitHelper(new AquaLearnIMDbContext());

//            Exhibit = new Exhibit()
//            {
//               //ExhibitId=22,
//               Name="Deep Sea",




//            };

//        }

//        [Fact]
//        public void Test_GetExhibits()
//        {
//            var db = Sut._idb;
//            db.Exhibit.Add(Exhibit);
//            db.SaveChanges();
            
//            var actual = Sut.GetExhibits();

//            Assert.NotNull(actual[0]);
//            Assert.True(actual.Count > 0);
//            Assert.True(actual[0].ExhibitId == 1);
//            Assert.True(actual[0].Name == "Deep Sea");


//        }

      
//    }
//}
