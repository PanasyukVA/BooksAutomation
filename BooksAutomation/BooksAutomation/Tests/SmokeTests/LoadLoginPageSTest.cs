using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadLoginPageSTest : CustomMethods
    {
        [TestMethod]
        public void LoadLoginPage()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                string expectedPageCaption;
                string actualPageCaption = "Log in.";

                // Act
                fixture.Pages.loginPage.GetPage();
                WaitUntil(fixture.driver, ExpectedConditions.ElementExists(By.XPath("//html")), TimeSpan.FromSeconds(10));
                expectedPageCaption = fixture.Pages.loginPage.CaptionLabel.Text;

                // Assert
                Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
            }
        }
    }
}
