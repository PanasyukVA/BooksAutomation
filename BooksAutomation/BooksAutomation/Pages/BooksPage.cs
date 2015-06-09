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

        [FindsBy(How = How.XPath, Using = @"//a[contains(@title = 'Log off')]")]
        public IWebElement LogoffLink;

        #endregion

        #region Labels
        [FindsBy(How = How.CssSelector, Using = ".navbar-brand")]
        public IWebElement CaptionLabel;

        #endregion

        #region Buttons
        [FindsBy(How = How.Id, Using = "btnCreateBook")]
        public IWebElement AddBookButton;

        [FindsBy(How = How.Id, Using = "btnCreateAuthor")]
        public IWebElement AddAuthorButton;

        [FindsBy(How = How.Id, Using = "btnEditBook")]
        public IWebElement EditBookButton;

        [FindsBy(How = How.Id, Using = "btnEditAuthor")]
        public IWebElement EditAuthorButton;

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
        }

        public void Logoff()
        {
            LogoffLink.Click();
        }

        public void AddAuthor(string authorName)
        {
            AddAuthorButton.Click();
            AuthorNameField.Text.Insert(0, authorName);
            SubmitAuthorButton.Click();
        }

        public void AddBook(string bookName, int[] authorsId)
        {
            AddBookButton.Click();
            BookNameField.Text.Insert(0, bookName);
            SelectElement SelectedAuthorsSelect = new SelectElement(SelectedAuthorsField);
            foreach(int authorId in authorsId)
                SelectedAuthorsSelect.SelectByIndex(authorId);
            SubmitBookButton.Click();
        }

        public void EditAuthor(int authorId)
        {
 
        }

        public void EditBook() 
        { }

        #endregion
    }
}
