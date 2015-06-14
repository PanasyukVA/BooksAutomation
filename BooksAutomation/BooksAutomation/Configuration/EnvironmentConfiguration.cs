using System;
using System.Collections.Specialized;
using System.Configuration;

namespace BooksAutomation.Configuration
{
    public class EnvironmentConfiguration
    {
        public int CurrentBorwser { get; set; }
        public int CountOfTestRun { get; set; }

        public string FirefoxProfilePath { get; set; }
        public string ChromeProfilePath { get; set; }

        public TimeSpan ImplicitTimeWait { get; set; }
        public TimeSpan WaitPageForLoad { get; set; }

        public string Books_UserEmail { get; set; }
        public string Books_UserPassword { get; set; }

        public string ScreenshotFolder { get; set; }

        public EnvironmentConfiguration()
        {
            NameValueCollection section = ConfigurationManager.GetSection("Main") as NameValueCollection;
            this.CurrentBorwser = int.Parse(section["CurrentBrowser"]);
            this.CountOfTestRun = int.Parse(section["CountOfTestRun"]);

            section = ConfigurationManager.GetSection("UserProfiles") as NameValueCollection;
            this.FirefoxProfilePath = section["FirefoxProfile"];
            this.ChromeProfilePath = section["ChromeProfile"];

            section = ConfigurationManager.GetSection("Timeouts") as NameValueCollection;
            this.ImplicitTimeWait = TimeSpan.FromSeconds(int.Parse(section["ImplicitTimeWait"]));
            this.WaitPageForLoad = TimeSpan.FromSeconds(int.Parse(section["WaitPageForLoad"]));

            section = ConfigurationManager.GetSection("BooksAccount") as NameValueCollection;
            this.Books_UserEmail = section["Books_UserEmail"];
            this.Books_UserPassword = section["Books_UserPassword"];
        }
    }
}
