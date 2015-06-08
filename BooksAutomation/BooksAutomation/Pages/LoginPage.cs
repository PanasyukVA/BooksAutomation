using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BooksAutomation.Pages
{
    public class LoginPage
    {
        public IWebDriver _driver;
        private BooksPage _booksPage;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
            
            this._booksPage = new BooksPage(_driver);
        }

        #region Fields
        [FindsBy(How = How.Id, Using = "#Email")]
        public IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "#Password")]
        public IWebElement PasswordTextBox;

        #endregion

        #region Buttons
        [FindsBy(How = How.CssSelector, Using = "#input[type=submit]")]
        public IWebElement LoginButton;

        #endregion

        #region Methods 
        public void GetPage()
        {
            _booksPage.GetPage();
            _booksPage.LoginLink.Click();
        }

        #endregion
    }
}
