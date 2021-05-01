using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SpecFlowSelenium.Configuration
{

    class WebConfiguration
    {
        private string browser;
        private IWebDriver webDriver;
        IConfiguration config;



        public WebConfiguration()
        {
            readConfigFile();
        }

        private void readConfigFile()
        {
            var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("webappsettings.json", optional: false, reloadOnChange: true);

            config = builder.Build();
            setBrowser();
            setWebDriver();
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
