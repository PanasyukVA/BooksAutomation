using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests.FunctionalTests
{
    [TestClass]
    public class AddAuthorFTest : BaseTest
    {
        [TestMethod, TestCategory("FunctionalTests")]
        public void AddAuthor()
        {
            // Arrange
            bool actualResult;
                
            // Act
            fixture.Pages.loginPage.GetPage();
            fixture.Pages.loginPage.Login(fixture.config.Books_UserEmail, fixture.config.Books_UserPassword);
            fixture.Pages.booksPage.AddAuthor("AuthorAddTest");
            actualResult = fixture.Pages.booksPage.AuthorResultModalLabel.Displayed;
                
            // Assert
            Assert.IsTrue(actualResult, "The author is not added.");
        }
    }
}
