using AquaLearn.MVCClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.Domain.Models;

namespace AquaLearn.MVCTest.Tests
{
  [TestClass]
  class UserControllerTest
  {
    [TestMethod]
    public void Test_Validation()
    {
      var user = new User();
      var sut = new UserController();
      var actual = sut.Validation(user) as ViewResult;
      Assert.AreEqual("Login", actual.ViewName);
    }

    [TestMethod]
    public void Test_Register()
    {
      var user = new User();
      var sut = new UserController();
      var actual = sut.Register(user) as ViewResult;
      Assert.AreEqual("Register", actual.ViewName);
    }

    [TestMethod]
    public void Test_Logout()
    {
      var sut = new UserController();
      var actual = sut.Logout() as ViewResult;
      Assert.AreEqual("Index", actual.ViewName);
    }
  }
}
