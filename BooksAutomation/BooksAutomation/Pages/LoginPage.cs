using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
            WaitUntil(this._driver, CustomExpectedConditions.ElementIsNotPresent(By.ClassName("blockUI")), TimeSpan.FromSeconds(10));
            booksPage.LoginLink.Click();
            WaitUntil(_driver, ExpectedConditions.ElementExists(By.XPath("//html")), TimeSpan.FromSeconds(10));
        }

        public void Login(string userEmail, string password)
        {
            EmailTextBox.SendKeys(userEmail);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            WaitUntil(this._driver, CustomExpectedConditions.ElementIsNotPresent(By.ClassName("blockUI")), TimeSpan.FromSeconds(10));
        }

        #endregion
    }
}
