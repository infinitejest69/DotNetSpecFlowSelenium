using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using static SpecFlowSelenium.Configuration.Configuration;

namespace SpecFlowSelenium.Configuration
{
    public class DriverConfiguration
    {
        private readonly Configuration configuration;
        public RemoteWebDriver WebDriver { get; private set; }
        public IWait<IWebDriver> Wait  { get; private set; }
        private ICapabilities capabilities;


        public DriverConfiguration()
        {
            configuration = new Configuration();
            createWebdriver();
        }

        public string getScreenShotBase64()
        {
            return WebDriver.GetScreenshot().AsBase64EncodedString;
        }

        private void createWebdriver()
        {
            switch (configuration.environemnt)
            {
                case Environemnt.LOCAL:
                    switch (configuration.browser)
                    {
                        case Browser.CHROME:
                            WebDriver = new ChromeDriver();
                            break;
                        case Browser.FIREFOX:
                            WebDriver = new FirefoxDriver();
                            break;
                        case Browser.EDGE:
                            WebDriver = new EdgeDriver();
                            break;
                    }
                    break;
                case Environemnt.REMOTE:

                    switch (configuration.browser)
                    {
                        case Browser.CHROME:
                            ChromeOptions ChromeOption = new ChromeOptions();
                            ChromeOption.AcceptInsecureCertificates = false;
                            ChromeOption.AddArgument("--headless");
                            ChromeOption.AddArgument("--whitelisted-ips");
                            ChromeOption.AddArgument("--no-sandbox");
                            ChromeOption.AddArgument("--disable-extensions");
                            capabilities = ChromeOption.ToCapabilities();
                            break;
                        case Browser.FIREFOX:
                            FirefoxOptions FirefoxOption = new FirefoxOptions();
                            capabilities = FirefoxOption.ToCapabilities();
                            break;
                        case Browser.EDGE:
                            EdgeOptions EdgeOption = new EdgeOptions();
                            capabilities = EdgeOption.ToCapabilities();
                            break;
                        default:
                            break;
                    }

                    WebDriver = new RemoteWebDriver(configuration.Hub, capabilities, TimeSpan.FromMinutes(5));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.
                    WebDriver.Manage().Window.Maximize();
                    WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configuration.Timeout);
                    Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30.00));

                    break;
                default:
                    throw new Exception("Somethings gone wrong creating the WebDriver in DriverConfiguration");
            }


            //CHROME and IE            
            //ChromeOptions Options = new ChromeOptions();

            //Options.AddArgument("--headless");
            //Options.AddArgument("--whitelisted-ips");
            //Options.AddArgument("--no-sandbox");
            //Options.AddArgument("--disable-extensions");
            //this.driver = new ChromeDriver(options);

            //webDriver = new FirefoxDriver();
            //    FirefoxOptions Options = new FirefoxOptions();

            //Options.AcceptInsecureCertificates = true;
            //Options.AddArguments(new List<string>() { "headless" });
            ////InternetExplorerOptions Options = new InternetExplorerOptions();
            //Options.PlatformName = "windows";
            //Options.AddAdditionalCapability("platform", "WIN10", true); // Supported values: "VISTA" (Windows 7), "WIN8" (Windows 8), "WIN8_1" (windows 8.1), "WIN10" (Windows 10), "LINUX" (Linux)
            //Options.AddAdditionalCapability("version", "latest", true); // you can specify version=latest or the version number like version="90". For IE you must always specify the version number.
            //Options.AddAdditionalCapability("gridlasticUser", USERNAME, true);
            //Options.AddAdditionalCapability("gridlasticKey", ACCESS_KEY, true);
            //Options.AddAdditionalCapability("video", "True", true);

            //webDriver.Manage().Window.Maximize(); // WINDOWS, DO NOT WORK FOR LINUX/firefox. If Linux/firefox set window size, max 1920x1080, like driver.Manage().Window.Size = new Size(1920, 1080);
            // driver.Manage().Window.Size = new Size(1920, 1080); // LINUX/firefox			 

            //var uri = getSeleniumHub();
            //var capabilities = new ChromeOptions().ToCapabilities();
            //var commandTimeout = TimeSpan.FromMinutes(5);
            //webDriver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);



        }
    }
}
