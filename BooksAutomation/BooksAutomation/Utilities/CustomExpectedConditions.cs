using System;
using OpenQA.Selenium;

namespace BooksAutomation.Utilities
{
    public static class CustomExpectedConditions
    {
        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
                {
                    try
                    {
                        return ElementIfVisible(element);
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                };
        }

        public static Func<IWebDriver, IWebElement> ElementIsClickable(IWebElement element)
        {
            return (driver) =>
                {
                    try
                    {
                        if (element != null && element.Displayed && element.Enabled)
                        {
                            return element;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                };
        }


        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (element != null && element.Displayed)
            {
                return element;
            }
            else
            {
                return null;
            }
        }
    }
}
