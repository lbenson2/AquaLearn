using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class TrashTest
    {
        Trash sut { get; set; }
        public TrashTest()
        {
            sut = new Trash()
            {
                Name =""
            };

        }

        [Fact]
        public void Test_TrashProperties()
        {

            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.TrashId);

        }
    }
}
