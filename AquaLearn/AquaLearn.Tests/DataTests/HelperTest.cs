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
    public class HelperTest
    {
        public RoleHelper Sutr { get; set; }
        public Role role { get; set; }

        public TrashHelper Sutt { get; set; }
        public Trash trash { get; set; }

        public FishHelper Sutf { get; set; }
        public Fish fish { get; set; }
    
        public PlantHelper Sutp { get; set; }
        public Plant plant { get; set; }

        public HazardHelper Suth { get; set; }
        public Hazard hazard { get; set; }

        public ExhibitHelper Sute { get; set; }
        public Exhibit exhibit { get; set; }

        public UserHelper Sutu { get; set; }
        public User user { get; set; }

        public QuizHelper Sutq { get; set; }
        public Quiz quiz { get; set; }

        public HelperTest()
        {
            Sutr = new RoleHelper(new AquaLearnIMDbContext());
            Sutt = new TrashHelper(new AquaLearnIMDbContext());
            Sutf = new FishHelper(new AquaLearnIMDbContext());
            Sutp = new PlantHelper(new AquaLearnIMDbContext());
            Suth = new HazardHelper(new AquaLearnIMDbContext());
            Sute = new ExhibitHelper(new AquaLearnIMDbContext());
            Sutu = new UserHelper(new AquaLearnIMDbContext());
            Sutq = new QuizHelper(new AquaLearnIMDbContext());
      
            role = new Role()
            {
                Name = "Teacher"
            };

            trash = new Trash()
            {
                Name = "Plastic Bottles",
                Schooling = true,
                Description = "Americans throw away 35 billion plastic water bottles every year.Making the ocean inhabitable for sea creatures."
            };

            fish = new Fish()
            {
                Name = "Shark",
                Schooling = false,
                Description = "Sharks are the most threatening predators in the ocean.",
                WaterType = new WaterType()
                {
                    WaterTypeId = 4,
                    Name = "Ocean Salt Water"
                }
            };
      
            plant = new Plant()
            {
                Name = "Algae",
                Description = "Algae are very diverse and found almost everywhere on the planet. They play an important role in many ecosystems, including providing the foundation for the aquatic food chains supporting all fisheries in the oceans and inland, as well as producing about 70 percent of all the air we breathe."
            };

            hazard = new Hazard()
            {
                Name = "Plastic",
                Description = "Pollution"
            };

            exhibit = new Exhibit()
            {
                Name = "Deep Sea",
            };

            user = new User()
            {
                Username = "Andy",
                Password = "Andy",
                ClassroomId = 22
            };

            quiz = new Quiz()
            {
               Name="Quiz"
            };

            Sutr.SetRole(role);
            Sutt.SetTrash(trash);
        }
    
        [Fact]
        public void Test_GetaRoles()
        {
            var actual = Sutr.GetRoles();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual[0].Name);
            Assert.True(actual[0].RoleId == 1);
            Assert.True(actual[0].Name == "Teacher");
        }
    
        [Fact]
        public void Test_GetbTrash()
        {
            var actual = Sutt.GetTrash();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].TrashId == 1);
            Assert.True(actual[0].Name == "Plastic Bottles");
            Assert.True(actual[0].Schooling == true);
            Assert.IsType<string>(actual[0].Description);
        }


        [Fact]
        public void Test_GetcFishes()
        {
            Sutf.SetFish(fish);
            var actual = Sutf.GetFishes();

            Assert.NotNull(actual[0]);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].FishId == 1);
            Assert.True(actual[0].Schooling == false);
            Assert.IsType<string>(actual[0].Description);
            Assert.True(actual[0].WaterType.WaterTypeId == 4);
            Assert.True(actual[0].WaterType.Name == "Ocean Salt Water");
        }

        [Fact]
        public void Test_GetdPlants()
        {
            Sutp.SetPlant(plant);
            var actual = Sutp.GetPlants();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].PlantId == 1);
        }

        [Fact]
        public void Test_GeteHazards()
        {
            Suth.SetHazard(hazard);
            var actual = Suth.GetHazards();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].HazardId == 1);
            Assert.True(actual[0].Description == "Pollution");
            Assert.True(actual[0].Name == "Plastic");
        }

        [Fact]
        public void Test_GetfExhibits()
        {
            Sute.SetExhibit(exhibit);

            var actual = Sute.GetExhibits();

            Assert.NotNull(actual[0]);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].ExhibitId == 1);
            Assert.True(actual[0].Name == "Deep Sea");
        }

        [Fact]
        public void Test_GetgUsers()
        {
            var db = Sutu._idb;
            db.User.Add(user);
            db.SaveChanges();

            var actual = Sutu.GetUserTest();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].UserId == 1);
            Assert.True(actual[0].Username == "Andy");
            Assert.True(actual[0].Password == "Andy");
            Assert.True(actual[0].ClassroomId == 22);
        }

        [Fact]
        public void Test_GethQuizzes()
        {
            var db = Sutq._idb;
            db.Quiz.Add(quiz);
            db.SaveChanges();

            var actual = Sutq.GetQuizTest();

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0].Name == "Quiz");
            Assert.True(Sutq.GetScoresByStudent(1).Count >= 0);
        }
    }
}
