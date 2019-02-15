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
    public class TrashHelperTest
    {
        public TrashHelper Sut { get; set; }
        public Trash Trash { get; set; }

        public TrashHelperTest()
        {
            Sut = new TrashHelper(new AquaLearnIMDbContext());


            Trash = new Trash()
            {
                Name="Plastic Bottles",
                Schooling=true,
                Description="Americans throw away 35 billion plastic water bottles every year.Making the ocean inhabitable for sea creatures."





            };

        }

        

        [Fact]
        public void Test_GetTrash()
        {
            var db = Sut._idb;
            db.Trash.Add(Trash);
            db.SaveChanges();
            var actual = Sut.GetTrash();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].TrashId == 1);
            Assert.True(actual[0].Name == "Plastic Bottles");
            Assert.True(actual[0].Schooling == true);
            Assert.IsType<string>(actual[0].Description);
            //Assert.True(actual[0].Description == "Americans throw away 35 billion plastic water bottles every year. Making the ocean inhabitable for sea creatures.");

        }
    }
}
