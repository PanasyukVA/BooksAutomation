using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using BooksAutomation.Configuration;

namespace BooksAutomation.Utilities
{
    public static class StaticCustomMethods
    {
        public static string Clean(this string str)
        {
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            str = str.Replace("\t", "");
            str = str.Replace("\\", "_");
            str = str.Replace("/", "_");
            str = str.Trim();

            return str;
        }

        public static IWebDriver SwitchTab(this IWebDriver driver)
        {
            System.Windows.Forms.SendKeys.SendWait("^({TAB})");
            return driver;
        }

        public static IWebDriver CloseTab(this IWebDriver driver)
        {
            System.Windows.Forms.SendKeys.SendWait("^(w)");
            return driver;
        }

        public static IWebDriver OpenTab(this IWebDriver driver)
        {
            System.Windows.Forms.SendKeys.SendWait("^(t)");
            return driver;
        }
    }

    public class CustomMethods
    {
        private EnvironmentConfiguration config = new EnvironmentConfiguration();

        public void WaitUntil(IWebDriver driver, Func<IWebDriver, IWebElement> condition, TimeSpan timeToWait)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(0));

            WebDriverWait wait = new WebDriverWait(driver, timeToWait);
            IWebElement element = wait.Until(condition);

            driver.Manage().Timeouts().ImplicitlyWait(config.ImplicitTimeWait);
        }

        public void WaitUntil(IWebDriver driver, Func<IWebDriver, bool> condition, TimeSpan timeToWait)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(0));

            WebDriverWait wait = new WebDriverWait(driver, timeToWait);
            bool element = wait.Until(condition);

            driver.Manage().Timeouts().ImplicitlyWait(config.ImplicitTimeWait);
        }

        public void WaitForAjax(IWebDriver driver, string javaScript, TimeSpan timeToWait)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(0));

            WebDriverWait wait = new WebDriverWait(driver, timeToWait);
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript(javaScript));

            driver.Manage().Timeouts().ImplicitlyWait(config.ImplicitTimeWait);

        }

        public void WaitForSuccessAjax(IWebDriver driver, TimeSpan timeToWait)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(0));

            WebDriverWait wait = new WebDriverWait(driver, timeToWait);
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));

            driver.Manage().Timeouts().ImplicitlyWait(config.ImplicitTimeWait);

        }

        public bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementVisible(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementClickable(IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public Dictionary<string, object> WebTimings(IWebDriver driver)
        {
            var webTiming = (Dictionary<string, object>)((IJavaScriptExecutor)driver)
                .ExecuteScript(@"var performance = window.performance || window.webkitPerformance || window.mozPerformance || window.msPerformance || {};
                                 var timings = performance.timing || {};
                                 return timings;");

            // * The dictionary returned will contain something like the following.
            // * The values are in milliseconds since 1/1/1970
            // * 
            // * connectEnd: 1280867925716
            // * connectStart: 1280867925687
            // * domainLookupEnd: 1280867925687
            // * domainLookupStart: 1280867925687
            // * fetchStart: 1280867925685
            // * legacyNavigationStart: 1280867926028
            // * loadEventEnd: 1280867926262
            // * loadEventStart: 1280867926155
            // * navigationStart: 1280867925685
            // * redirectEnd: 0
            // * redirectStart: 0
            // * requestEnd: 1280867925716
            // * requestStart: 1280867925716
            // * responseEnd: 1280867925940
            // * responseStart: 1280867925919
            // * unloadEventEnd: 1280867925940

            return webTiming;
        }

        public void TakeScreenshot(IWebDriver driver, string testName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] screenshotAsByteArray = ss.AsByteArray;
            string ScreenshotFileName = generateFileName(testName);

            if (!Directory.Exists(config.ScreenshotFolder))
            {
                Directory.CreateDirectory(config.ScreenshotFolder);
            }

            ss.SaveAsFile(Path.Combine(config.ScreenshotFolder, ScreenshotFileName), ImageFormat.Png);
        }

        public string generateFileName(string testName)
        {
            Random generator = new Random();
            return string.Format("{0}_{1}_{2}.png", testName, DateTime.Now.ToString("yyyyMMddHHmmss"), generator.Next(0, 1000));
        }
    }
}
