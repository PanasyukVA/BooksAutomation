using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.SmokeTests
{
    [TestClass]
    public class LoadLoginPageSTest : BaseTest
    {
        [TestMethod, TestCategory("SmokeTests")]
        public void LoadLoginPage()
        {
            // Arrange
            string expectedPageCaption = "Log iin.";
            string actualPageCaption;

            // Act
            fixture.Pages.loginPage.GetPage();
            actualPageCaption = fixture.Pages.loginPage.CaptionLabel.Text;

            // Assert
            Assert.AreEqual(expectedPageCaption, actualPageCaption, String.Format("The {0} page is not loaded", expectedPageCaption));
        }
    }
}
