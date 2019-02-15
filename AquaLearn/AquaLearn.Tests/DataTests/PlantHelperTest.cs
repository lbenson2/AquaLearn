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
    public class PlantHelperTest
    {
        public PlantHelper Sut { get; set; }
        public Plant Plant { get; set; }

        public PlantHelperTest()
        {
            Sut = new PlantHelper(new AquaLearnIMDbContext());

            Plant = new Plant()
            {
                Name="Algae",
                Description="Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe."






            };

        }

       

        [Fact]
        public void Test_GetPlants()
        {
            var db = Sut._idb;
            db.Plant.Add(Plant);
            db.SaveChanges();
            var actual = Sut.GetPlants();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].PlantId == 1);
            //Assert.IsType<string>(actual[0].Description);
            //Assert.True(actual[0].Description == "Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe.");
            Assert.True(actual[0].Name == "Algae");
        }
    }
}
