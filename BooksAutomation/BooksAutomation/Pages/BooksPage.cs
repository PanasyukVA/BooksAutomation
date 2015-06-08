using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace BooksAutomation.Pages
{
    public class BooksPage
    {
        public IWebDriver _driver;

        public BooksPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        #region Elements
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink;

        [FindsBy(How = How.CssSelector, Using = ".navbar-brand")]
        public IWebElement PageCaption;

        #endregion

        #region Methods
        public void GetPage()
        {
            _driver.Navigate().GoToUrl("http://localhost/BooksMVC/");
        }

        #endregion
    }
}
