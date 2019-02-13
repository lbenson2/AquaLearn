using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class UserTest
    {
        User sut { get; set; }
        public UserTest()
        {
            sut = new User()
            {

            };

        }

        [Fact]
        public void Test_UserProperties()
        {
            Assert.IsType<Role>(sut.UserRole);
            Assert.IsType<string>(sut.Username);
            Assert.IsType<string>(sut.Password);
            
            Assert.IsType<int>(sut.UserId);
            Assert.IsType<int>(sut.ClassroomId);
            Assert.IsType<List<Quiz>>(sut.Quizzes);
        }
    }
}
