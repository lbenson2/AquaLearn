using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using AquaLearn.MVCClient.Models;
using Xunit;

namespace AquaLearn.Tests.MvcTests
{
    public class ModelTest
    {
        UserModel sut { get; set; }
        ExhibitModel sute { get; set; }
        ErrorViewModel sutr { get; set; }
        ClassroomModel sutc { get; set; }

        public ModelTest()
        {
            sut = new UserModel()
            {
                //UserId = 22,
                Name = "Andy",
                Username = "Andy",
                Password = "Andy",
                Quizzes = new List<Quiz>()
                //ClassroomId = 22

            };

            sute = new ExhibitModel()
            {
                Name = "Andy",
                Fishes = new List<Fish>(),
                Trash = new List<Trash>(),
                Plants = new List<Plant>()
            };

            sutr = new ErrorViewModel()
            {
                RequestId = "Andy"
            };

            sutc = new ClassroomModel()
            {
                Name = "Andy"
            };

        }

        [Fact]
        public void Test_UserModel()
        {
            Assert.IsType<int>(sut.UserId);
            Assert.IsType<string>(sut.Username);
            Assert.IsType<string>(sut.Password);
            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.RoleId);
            Assert.IsType<int>(sut.ClassroomId);
            Assert.IsType<List<Quiz>>(sut.Quizzes);
        }

        [Fact]
        public void Test_ExhibitModel()
        {
            Assert.IsType<int>(sute.ExhibitId);
            Assert.IsType<string>(sute.Name);
            Assert.IsType<List<Plant>>(sute.Plants);
            Assert.IsType<List<Trash>>(sute.Trash);
            Assert.IsType<List<Fish>>(sute.Fishes);

        }

        [Fact]
        public void Test_ErrorViewModel()
        {
            Assert.IsType<string>(sutr.RequestId);

            Assert.IsType<bool>(sutr.ShowRequestId);

        }

        [Fact]
        public void Test_ClassroomModel()
        {
            Assert.IsType<string>(sutc.Name);

            Assert.IsType<int>(sutc.ClassroomId);

        }

    }
}
