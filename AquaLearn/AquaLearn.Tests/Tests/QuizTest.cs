using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AquaLearn.Domain.Models;

namespace AquaLearn.Tests.Tests
{
    public class QuizTest
    {
        Quiz sut { get; set; }
        public QuizTest()
        {
            sut = new Quiz()
            {
               
            };

        }

        [Fact]
        public void Test_QuizProperties()
        {

            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.QuizId);

        }

     
    }
}

