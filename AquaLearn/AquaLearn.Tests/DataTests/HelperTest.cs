//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using AquaLearn.Data.Helpers;
//using AquaLearn.Domain.Models;
//using Xunit;
//using AquaLearn.Data;

//namespace AquaLearn.Tests.DataTests
//{
//    public class HelperTest
//    {
//        public PlantHelper Sutp { get; set; }
//        public Plant plant { get; set; }

//        public FishHelper Sutf { get; set; }
//        public Fish fish { get; set; }

//        public RoleHelper Sutr { get; set; }
//        public Role role { get; set; }

//        //public TrashHelper Sutt { get; set; }
//        //public Trash Trash { get; set; }

//        public HelperTest()
//        {
//            Sutp = new PlantHelper(new AquaLearnIMDbContext());
//            Sutf = new FishHelper(new AquaLearnIMDbContext());
//            Sutr = new RoleHelper(new AquaLearnIMDbContext());
//           // Sutt = new TrashHelper(new AquaLearnIMDbContext());

//            plant = new Plant()
//            {
//                Name = "Algae",
//                Description = "Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe."


//            };

//            fish = new Fish()
//            {
//                Name = "Shark",
//                Schooling = false,
//                Description = "Sharks are the most threatening predators in the ocean."

//            };

//            role = new Role()
//            {

//                Name = "Teacher"

//            };

          
//            Sutp.SetPlant(plant);
//            Sutf.SetFish(fish);
//            Sutr.SetRole(role);
//            //Sutt.SetTrash(trash);




//        }

//        [Fact]
//        public void Test_GetPlants()
//        {
//            //var db = Sut._idb;
//            //db.Plant.Add(Plant);
//            //db.SaveChanges();
//            var actual = Sutp.GetPlants();

//            Assert.NotNull(actual);
//            Assert.True(actual.Count > 0);
//            Assert.True(actual[0].PlantId == 1);
//            //Assert.IsType<string>(actual[0].Description);
//            //Assert.True(actual[0].Description == "Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe.");
//            Assert.True(actual[0].Name == "Algae");
//        }


//        [Fact]
//        public void Test_GetFishes()
//        {
//            //var db = Sut._idb;
//            //db.Fish.Add(Fish);
//            //db.SaveChanges();
//            var actual = Sutf.GetFishes();

//            Assert.NotNull(actual[0]);
//            Assert.True(actual.Count > 0);
//            Assert.True(actual[0].FishId == 1);
//            Assert.True(actual[0].Name == "Shark");
//            Assert.True(actual[0].Schooling == false);
//            Assert.IsType<string>(actual[0].Description);
//            // Assert.True(actual[0].Description == "Sharks are the most threatening predators in the ocean.");

//        }

//        [Fact]
//        public void Test_GetRoles()
//        {
//            //var db = Sut._idb;
//            //db.Role.Add(Role);
//            //db.SaveChanges();
//            var actual = Sutr.GetRoles();


//            Assert.NotNull(actual);
//            Assert.True(actual.Count > 0);
//            Assert.NotNull(actual[0].Name);
//            Assert.True(actual[0].RoleId == 1);
//            Assert.True(actual[0].Name == "Teacher");
//            //Assert.NotNull(actual.Username == "Spkr");
//        }
//    }
//}
