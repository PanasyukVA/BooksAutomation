using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadLoginPageSTest
    {
        [TestMethod, TestCategory("SmokeTests")]
        public void LoadLoginPage()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                string expectedPageCaption = "Log in.";
                string actualPageCaption;

                // Act
                fixture.Pages.loginPage.GetPage();
                actualPageCaption = fixture.Pages.loginPage.CaptionLabel.Text;

                // Assert
                Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
            }
        }
    }
}
