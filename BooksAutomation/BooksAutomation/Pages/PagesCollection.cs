using OpenQA.Selenium;

namespace BooksAutomation.Pages
{
    public class PagesCollection
    {
        private IWebDriver driver;

        public LoginPage loginPage { get; private set; }
        public BooksPage booksPage { get; private set; }
        
        public PagesCollection(IWebDriver driver)
        {
            this.driver = driver;

            this.loginPage = new LoginPage(driver);
            this.booksPage = new BooksPage(driver);
        }
    }
}
