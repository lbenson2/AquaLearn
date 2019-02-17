using AquaLearn.MVCClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AquaLearn.MVCClient.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AquaLearn.MVCTest.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
        [TestMethod]
        public void Test_Index()
        {
            var icontroller = new HomeController();
            var iresult = icontroller.Index() as ViewResult;
            Assert.AreEqual("Index", iresult.ViewName);
        }

       

        [TestMethod]
        public void Test_Privacy()
        {
            var pcontroller = new HomeController();
            var presult = pcontroller.Privacy() as ViewResult;
            Assert.AreEqual("Privacy", presult.ViewName);
        }

        [TestMethod]
        public void Test_Quiz()
        {
            var qcontroller = new HomeController();
            var qresult = qcontroller.Quiz() as ViewResult;
            Assert.AreEqual("Quiz", qresult.ViewName);
        }

        [TestMethod]
        public void Test_Login()
        {
            var controller = new HomeController();
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }

        [TestMethod]
        public void Test_Register()
        {
            var controller = new HomeController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }

        //[TestMethod]
        //public void Test_PVR()
        //{
        //    //string id="a";
        //    var pvrcontroller = new HomeController();
        //    var pvrresult = pvrcontroller.AddPartialToView("_StudentRegPartial") as PartialViewResult;
        //    //Assert.AreEqual("Register", pvrresult.ViewName);
        //}

    }
}
