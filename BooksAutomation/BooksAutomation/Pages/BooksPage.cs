using System;
using BooksAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace BooksAutomation.Pages
{
    public class BooksPage : CustomMethods
    {
        public IWebDriver _driver;

        public BooksPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        #region Links
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink;

        #endregion

        #region Labels
        [FindsBy(How = How.CssSelector, Using = ".navbar-brand")]
        public IWebElement CaptionLabel;

        [FindsBy(How = How.Id, Using = "bookResultModal")]
        public IWebElement BookResultModalLabel;

        [FindsBy(How = How.Id, Using = "authorResultModal")]
        public IWebElement AuthorResultModalLabel;

        #endregion

        #region Buttons
        [FindsBy(How = How.Id, Using = "btnCreateBook")]
        public IWebElement AddBookButton;

        [FindsBy(How = How.Id, Using = "btnCreateAuthor")]
        public IWebElement AddAuthorButton;

        [FindsBy(How = How.Id, Using = "btnSubmitAuthor")]
        public IWebElement SubmitAuthorButton;

        [FindsBy(How = How.Id, Using = "btnSubmitBook")]
        public IWebElement SubmitBookButton;

        #endregion

        #region Fields
        [FindsBy(How = How.Id, Using = "BookName")]
        public IWebElement BookNameField;

        [FindsBy(How = How.Id, Using = "SelectedAuthors")]
        public IWebElement SelectedAuthorsField;

        [FindsBy(How = How.Id, Using = "AuthorName")]
        public IWebElement AuthorNameField;

        #endregion

        #region Methods
        public void GetPage()
        {
            _driver.Navigate().GoToUrl("http://localhost/BooksMVC/");
            WaitUntil(_driver, ExpectedConditions.ElementExists(By.XPath("//html")), TimeSpan.FromSeconds(10));
        }

        public void AddAuthor(string authorName)
        {
            AddAuthorButton.Click();

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(AuthorNameField), TimeSpan.FromSeconds(10));
            AuthorNameField.SendKeys(authorName);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SubmitAuthorButton), TimeSpan.FromSeconds(10));
            SubmitAuthorButton.Click();
            WaitForSuccessAjax(_driver, TimeSpan.FromSeconds(10));
        }

        public void AddBook(string bookName, int[] bookAuthors)
        {
            AddBookButton.Click();

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(BookNameField), TimeSpan.FromSeconds(10));
            BookNameField.SendKeys(bookName);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SelectedAuthorsField), TimeSpan.FromSeconds(10));
            SelectElement SelectedAuthorsSelect = new SelectElement(SelectedAuthorsField);
            foreach(int authorId in bookAuthors)
                SelectedAuthorsSelect.SelectByIndex(authorId);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SubmitBookButton), TimeSpan.FromSeconds(10));
            SubmitBookButton.Click();
            WaitForSuccessAjax(_driver, TimeSpan.FromSeconds(10));
        }

        public void EditAuthor(int authorId, string authorNewName)
        {
            _driver.FindElement(By.CssSelector(String.Format("#aEditAuthor[data-authorid='{0}']", authorId))).Click();

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(AuthorNameField), TimeSpan.FromSeconds(10));
            AuthorNameField.Clear();
            AuthorNameField.SendKeys(authorNewName);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SubmitAuthorButton), TimeSpan.FromSeconds(10));
            SubmitAuthorButton.Click();
            WaitForSuccessAjax(_driver, TimeSpan.FromSeconds(10));
        }

        public void EditBook(int bookId, string bookNewName, int[] bookNewAuthors) 
        {
            _driver.FindElement(By.CssSelector(String.Format("#btnEditBook[data-bookid='{0}']", bookId))).Click();

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(BookNameField), TimeSpan.FromSeconds(10));
            BookNameField.Clear();
            BookNameField.SendKeys(bookNewName);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SelectedAuthorsField), TimeSpan.FromSeconds(10));
            SelectElement SelectedAuthorsSelect = new SelectElement(SelectedAuthorsField);
            foreach (int authorId in bookNewAuthors)
                SelectedAuthorsSelect.SelectByIndex(authorId);

            WaitUntil(_driver, CustomExpectedConditions.ElementIsVisible(SubmitBookButton), TimeSpan.FromSeconds(10));
            SubmitBookButton.Click();
            WaitForSuccessAjax(_driver, TimeSpan.FromSeconds(10));
        }

        #endregion
    }
}
