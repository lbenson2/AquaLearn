using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class ClassroomTest
    {
        Classroom sut { get; set; }
        public ClassroomTest()
        {
            sut = new Classroom()
            { };

        }

        [Fact]
        public void Test_ClassroomProperties()
        {

            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.ClassroomId);
           // Assert.IsType<List<User>>(sut.Students);

        }
    }
}
