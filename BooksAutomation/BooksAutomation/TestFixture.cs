using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using BooksAutomation.Configuration;
using BooksAutomation.Pages;

namespace BooksAutomation
{
    public class TestFixture : IDisposable
    {
        #region Set Up/Down

        public IWebDriver driver;

        public PagesCollection Pages;

        public EnvironmentConfiguration config = new EnvironmentConfiguration();       

        public TestFixture()
        {
            switch (config.CurrentBorwser)
            {
                case 0:
                    {
                        FirefoxProfile firefoxProfile = new FirefoxProfile(config.FirefoxProfilePath);
                        firefoxProfile.EnableNativeEvents = true;
                        driver = new FirefoxDriver(firefoxProfile);
                        Debug.WriteLine("Tests will be run (or rerun) in Firefox with custom profile...");
                    }
                    break;
                case 1:
                    {                       
                        driver = new ChromeDriver();
                        driver.Manage().Window.Maximize();
                        Debug.WriteLine("Tests will be run (or rerun) in Google Chrome...");
                    }
                    break;
                case 2:
                    {
                        driver = new InternetExplorerDriver();
                        driver.Manage().Window.Maximize();
                        Debug.WriteLine("Tests will be run (or rerun) in Internet Explorer...");
                    }
                    break;
                case 3:
                    {
                        driver = new SafariDriver();
                        Debug.WriteLine("Tests will be run (or rerun) in Apple Safari...");
                    }
                    break;
                case 4:
                    {
                        driver = new OperaDriver();
                        Debug.WriteLine("Tests will be run (or rerun) in Opera...");
                    }
                    break;
            }

            // Specifies the amount of time the driver should wait when searching for an
            // element if it is not immediately present
            driver.Manage().Timeouts().ImplicitlyWait(config.ImplicitTimeWait);

            // Page Load Timeout
            driver.Manage().Timeouts().SetPageLoadTimeout(config.WaitPageForLoad);

            this.InitializePages(driver);
        }

        private void InitializePages(IWebDriver driver)
        {
            this.Pages = new PagesCollection(driver);
        }

        public void Dispose()
        {
            //driver.Manage().Cookies.DeleteAllCookies();
            //driver.Quit();
        }

        #endregion
    }
}
