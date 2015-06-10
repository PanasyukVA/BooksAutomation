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
        [TestMethod, TestCategory("FunctionalTests")]
        public void AddBook()
        {
            using (TestFixture fixture = new TestFixture())
            {
                // Arrange
                bool actualResult;

                // Act
                fixture.Pages.loginPage.GetPage();
                fixture.Pages.loginPage.Login(fixture.config.Books_UserEmail, fixture.config.Books_UserPassword);
                fixture.Pages.booksPage.AddBook("BookAddTest", new int[]{1, 2});
                actualResult = fixture.Pages.booksPage.BookResultModalLabel.Displayed;

                // Assert
                Assert.IsTrue(actualResult, "The book is not added.");
            }
        }
    }
}
