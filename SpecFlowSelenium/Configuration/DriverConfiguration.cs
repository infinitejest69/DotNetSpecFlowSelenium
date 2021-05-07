using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
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

        private string getSeleniumHub()
        {
            return config.GetSection("SeleniumHub").Value;
        }

        public string getBrowser()
        {
            return browser;
        }

        private void setWebDriver()
        {
            if (!string.IsNullOrEmpty(getSeleniumHub()))
            {
                //CHROME and IE            
                ChromeOptions Options = new ChromeOptions();
                Options.AddArguments(new List<string>() { "headless" });

                ////InternetExplorerOptions Options = new InternetExplorerOptions();
                //Options.PlatformName = "windows";
                //Options.AddAdditionalCapability("platform", "WIN10", true); // Supported values: "VISTA" (Windows 7), "WIN8" (Windows 8), "WIN8_1" (windows 8.1), "WIN10" (Windows 10), "LINUX" (Linux)
                //Options.AddAdditionalCapability("version", "latest", true); // you can specify version=latest or the version number like version="90". For IE you must always specify the version number.
                //Options.AddAdditionalCapability("gridlasticUser", USERNAME, true);
                //Options.AddAdditionalCapability("gridlasticKey", ACCESS_KEY, true);
                //Options.AddAdditionalCapability("video", "True", true);


                webDriver = new RemoteWebDriver(
                  new Uri(getSeleniumHub()), Options.ToCapabilities(), TimeSpan.FromSeconds(600));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.

                //webDriver.Manage().Window.Maximize(); // WINDOWS, DO NOT WORK FOR LINUX/firefox. If Linux/firefox set window size, max 1920x1080, like driver.Manage().Window.Size = new Size(1920, 1080);
                                                      // driver.Manage().Window.Size = new Size(1920, 1080); // LINUX/firefox			 





                //var uri = getSeleniumHub();
                //var capabilities = new ChromeOptions().ToCapabilities();
                //var commandTimeout = TimeSpan.FromMinutes(5);
                //webDriver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);

            }
            else
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
            }
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(config.GetSection("ImplicitWait").Value));

        }

        public RemoteWebDriver GetWebDriver()
        {
            return webDriver;
        }

    }
}
