using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace SpecFlowSelenium.Configuration
{

    class DriverConfiguration
    {
        private string browser;
        private RemoteWebDriver webDriver;
        IConfiguration config;



        public DriverConfiguration()
        {
            readConfigFile();
            setBrowser();
            setWebDriver();
        }

        public string getScreenShotBase64()
        {
            return webDriver.GetScreenshot().AsBase64EncodedString;

        }

        private void readConfigFile()
        {
            var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("webappsettings.json", optional: false, reloadOnChange: true);

            config = builder.Build();

        }

        private void setBrowser()
        {
            browser = config.GetSection("Browser").Value.ToLower();
        }

        public string getBrowser()
        {
            return browser;
        }

        private void setWebDriver()
        {
            switch (getBrowser())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "edge":
                    webDriver = new EdgeDriver();
                    break;
                default:
                    throw new Exception($"Unknown Driver {config.GetSection("Browser")}");
            }
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(config.GetSection("ImplicitWait").Value));

        }

        public IWebDriver GetWebDriver()
        {
            return webDriver;
        }

    }
}
