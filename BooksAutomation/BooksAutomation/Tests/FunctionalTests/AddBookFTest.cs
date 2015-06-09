using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class AddBookFTest : CustomMethods
    {
        [TestMethod]
        public void AddBook()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                
                // Act
                
                // Assert
            }
        }
    }
}
