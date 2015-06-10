using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LogInOnSiteSTest
    {
        [TestMethod, TestCategory("SmokeTests")]
        public void LogInOnSite()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                bool actualResult;

                // Act
                fixture.Pages.loginPage.GetPage();
                fixture.Pages.loginPage.Login(fixture.config.Books_UserEmail, fixture.config.Books_UserPassword);
                try
                {
                    actualResult = fixture.driver.FindElement(By.LinkText(String.Format("Hello {0}!", fixture.config.Books_UserEmail))).Displayed;
                }
                catch (NoSuchElementException)
                {
                    actualResult = false;
                }

                // Assert
                Assert.IsTrue(actualResult, "Unable to log in on the site");
            }
        }
    }
}
