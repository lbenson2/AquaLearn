﻿using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;
using Xunit;

namespace AquaLearn.Tests.Tests
{
    public class FishTest
    {
        Fish sut { get; set; }
        public FishTest()
        {
            sut = new Fish()
            {
                Name = ""
            };

        }

        [Fact]
        public void Test_FishProperties()
        {
            Assert.IsType<string>(sut.Name);
        }



    }

}