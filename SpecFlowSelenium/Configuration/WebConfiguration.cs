using System;
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
        IConfiguration configuration { get; set; }



        public WebConfiguration()
        {
        }

        public string getBrowser()
        {
//            configuration = new ConfigurationBuilder()
//.AddJsonFile("WebConfiguration.json", true, true)
//.Build();
            return configuration.GetSection("Browser").Value.ToLower();
        }

        public IWebDriver GetWebDriver() {
            switch (getBrowser())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    return webDriver;
                case "firefox":
                    webDriver = new FirefoxDriver();
                    return webDriver;
                case "edge":
                    webDriver = new EdgeDriver();
                    return webDriver;
                default:
                    throw new Exception($"Unknown Driver {getBrowser()}");
            }

        }

    }
}
