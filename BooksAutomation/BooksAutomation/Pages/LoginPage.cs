using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BooksAutomation.Utilities;

namespace BooksAutomation.Pages
{
    public class LoginPage : CustomMethods
    {
        public IWebDriver _driver;
        private BooksPage booksPage;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
            
            this.booksPage = new BooksPage(_driver);
        }

        #region Fields
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "h2")]
        public IWebElement CaptionLabel;

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink;

        #endregion

        #region Buttons
        [FindsBy(How = How.CssSelector, Using = "input[type=submit]")]
        public IWebElement LoginButton;

        #endregion

        #region Methods 
        public void GetPage()
        {
            booksPage.GetPage();
            WaitForSuccessAjax(this._driver, TimeSpan.FromSeconds(10));
            booksPage.LoginLink.Click();
        }

        public void Login(string userEmail, string password)
        {
            EmailTextBox.Text.Insert(0, userEmail);
            PasswordTextBox.Text.Insert(0, password);
            LoginButton.Click();
        }

        #endregion
    }
}
