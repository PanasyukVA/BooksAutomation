using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadMainPage : CustomMethods
    {
        [TestMethod]
        public void LoadPage()
        {
            // Arrange
            TestFixture fixture = new TestFixture();
            string expectedPageCaption;
            string actualPageCaption = "Books";
            
            // Act
            fixture.Pages.booksPage.GetPage();
            WaitUntil(fixture.driver, ExpectedConditions.ElementExists(By.XPath("//html")), fixture.config.WaitPageForLoad);
            expectedPageCaption = fixture.Pages.booksPage.PageCaption.Text;
            
            // Assert
            Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
        }
    }
}
