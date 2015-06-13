using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.FunctionalTests
{
    [TestClass]
    public class EditAuthorFTest : BaseTest
    {
        [TestMethod, TestCategory("FunctionalTests")]
        public void EditAuthor()
        {
            // Arrange
            bool actualResult;

            // Act
            fixture.Pages.loginPage.GetPage();
            fixture.Pages.loginPage.Login(fixture.config.Books_UserEmail, fixture.config.Books_UserPassword);
            fixture.Pages.booksPage.EditAuthor(1, "AuthorEditTest");
            actualResult = fixture.Pages.booksPage.AuthorResultModalLabel.Displayed;

            // Assert
            Assert.IsTrue(actualResult, "The author is not edited.");
        }
    }
}
