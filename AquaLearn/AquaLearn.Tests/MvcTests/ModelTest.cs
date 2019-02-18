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

        public ModelTest()
            {
                sut = new UserModel()
                {
                    //UserId = 22,
                    //Username = "Andy",
                    //Password = "Andy",
                    //ClassroomId = 22

                };

            sute = new ExhibitModel()
            {

            };

            sutr = new ErrorViewModel()
            {

            };

            }

        [Fact]
        public void Test_UserModel()
        {
            Assert.IsType<int>(sut.UserId);
            //Assert.IsType<string>(sut.Username);
            //Assert.IsType<string>(sut.Password);
            //Assert.IsType<string>(sut.Name);
            //Assert.IsType<int>(sut.UserId);
            Assert.IsType<int>(sut.ClassroomId);
            //Assert.IsType<List<Quiz>>(sut.Quizzes);
        }

        [Fact]
        public void Test_ExhibitModel()
        {
            Assert.IsType<int>(sute.ExhibitId);
            //Assert.IsType<string>(sut.Username);
            //Assert.IsType<string>(sut.Password);
            //Assert.IsType<string>(sute.Name);
            //Assert.IsType<int>(sut.UserId);
           // Assert.IsType<int>(sut.ClassroomId);
            //Assert.IsType<List<Quiz>>(sut.Quizzes);
        }

        [Fact]
        public void Test_ErrorViewModel()
        {
            //Assert.IsType<string>(sutr.RequestId);
            //Assert.IsType<string>(sut.Username);
            //Assert.IsType<string>(sut.Password);
            //Assert.IsType<string>(sut.Name);
            //Assert.IsType<int>(sut.UserId);
            Assert.IsType<bool>(sutr.ShowRequestId);
            //Assert.IsType<List<Quiz>>(sut.Quizzes);
        }

    }
    }
