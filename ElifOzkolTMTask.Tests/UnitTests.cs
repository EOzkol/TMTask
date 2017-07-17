using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElifOzkolTMTask.Controllers;
using System.Collections.Generic;
using ElifOzkolTMTask.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace ElifOzkolTMTask.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMultipleOfBy3()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("3", "3");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("fizz ", contentResult.Content.result);

        }

        [TestMethod]
        public void TestMultipleOfBy5()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("5", "5");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("buzz ", contentResult.Content.result);

        }

        [TestMethod]
        public void TestMultipleOfBy3And5()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("15", "15");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("fizzbuzz ", contentResult.Content.result);

        }

        [TestMethod]
        
        public void TestNoRuleReturnInputs()
        {
            var controller = new FizzBuzzController();
            var response = controller.Get("1", "2");
            var contentResult = response as OkNegotiatedContentResult <FizzBuzzResult>;
              
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("1 2 ", contentResult.Content.result);

        }
        
        [TestMethod]
        public void TestExpectedSummaryFizz()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("1", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("5", contentResult.Content.summary.fizz);

        }

        [TestMethod]
        public void TestExpectedSummaryBuzz()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("1", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("3", contentResult.Content.summary.buzz);

        }

        [TestMethod]
        public void TestExpectedSummaryFizzBuzz()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("1", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("1", contentResult.Content.summary.fizzbuzz);

        }

        [TestMethod]
        public void TestExpectedSummaryInteger()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("1", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("11", contentResult.Content.summary.integer);

        }

        [TestMethod]
        public void TestExpectedResult()
        {

            var controller = new FizzBuzzController();
            var response = controller.Get("1", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz ", contentResult.Content.result);

        }

        [TestMethod]
        public void TestLargeInputRange()
        {
            var controller = new FizzBuzzController();
            var response = controller.Get("1", "100000");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNull(contentResult);
        }

        [TestMethod]
        public void TestIncorrectFormatInput()
        {
            var controller = new FizzBuzzController();
            var response = controller.Get("a", "20");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNull(contentResult);
        }

        [TestMethod]
        public void TestInputRange()
        {
            var controller = new FizzBuzzController();
            var response = controller.Get("20", "1");
            var contentResult = response as OkNegotiatedContentResult<FizzBuzzResult>;

            Assert.IsNull(contentResult);
        }




    }
}
