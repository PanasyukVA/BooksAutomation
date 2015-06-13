using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadMainPageSTest : BaseTest
    {
        [TestMethod, TestCategory("SmokeTests")]
        public void LoadMainPage()
        {
            // Arrange
            string expectedPageCaption = "Books";
            string actualPageCaption;

            // Act
            fixture.Pages.booksPage.GetPage();
            actualPageCaption = fixture.Pages.booksPage.CaptionLabel.Text;

            // Assert
            Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
        }
    }
}
