﻿using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;
using AquaLearn.Data.Helpers;

namespace AquaLearn.Tests.Tests
{
    public class UserTest
    {
        User sut { get; set; }
        public UserTest()
        {
            sut = new User()
            {
                //UserId = 22,
                Username = "Andy",
                Password = "Andy",
                ClassroomId = 22

            };

        }

        [Fact]
        public void Test_UserProperties()
        {
            Assert.IsType<int>(sut.RoleId);
            Assert.IsType<string>(sut.Username);
            Assert.IsType<string>(sut.Password);
            
            Assert.IsType<int>(sut.UserId);
            Assert.IsType<int>(sut.ClassroomId);
            Assert.IsType<List<Quiz>>(sut.Quizzes);
        }

        [Fact]
        public void Test_HelperSetUser()
        {
           // Assert.True(UserHelper.GetUsers(sut));
        }
    }
}
