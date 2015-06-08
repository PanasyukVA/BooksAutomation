using System;
using System.Configuration;
using System.IO;
// using ST.Utilities;

namespace ST.Configuration
{
    public class EnvironmentConfiguration
    {
        public int CurrentBorwser { get; set; }
        public int CountOfTestRun { get; set; }

        public string FirefoxProfilePath { get; set; }
        public string ChromeProfilePath { get; set; }

        public TimeSpan ImplicitTimeWait { get; set; }
        public TimeSpan WaitPageForLoad { get; set; }

        public string ST_CustomerId { get; set; }
        public string ST_Username { get; set; }
        public string ST_Password { get; set; }

        public string ScreenshotFolder { get; set; }

        public EnvironmentConfiguration()
        {
            this.CurrentBorwser = int.Parse(ConfigurationManager.AppSettings["CurrentBrowser"]);
            this.CountOfTestRun = int.Parse(ConfigurationManager.AppSettings["CountOfTestRun"]);

            this.FirefoxProfilePath = ConfigurationManager.AppSettings["FirefoxProfile"];
            this.ChromeProfilePath = ConfigurationManager.AppSettings["ChromeProfile"];

            this.ImplicitTimeWait = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["ImplicitTimeWait"]));
            this.WaitPageForLoad = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["WaitPageForLoad"]));

            this.ST_CustomerId = ConfigurationManager.AppSettings["ST_CustomerId"];
            this.ST_Username = ConfigurationManager.AppSettings["ST_Username"];
            this.ST_Password = ConfigurationManager.AppSettings["ST_Password"];

            this.ScreenshotFolder = ConfigurationManager.AppSettings["SavePath"];

        }

    }
}
