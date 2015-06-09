using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadMainPageSTest : CustomMethods
    {
        [TestMethod]
        public void LoadMainPage()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                string expectedPageCaption;
                string actualPageCaption = "Books";

                // Act
                fixture.Pages.booksPage.GetPage();
                WaitUntil(fixture.driver, ExpectedConditions.ElementExists(By.XPath("//html")), fixture.config.WaitPageForLoad);
                expectedPageCaption = fixture.Pages.booksPage.CaptionLabel.Text;

                // Assert
                Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
            }
        }
    }
}
