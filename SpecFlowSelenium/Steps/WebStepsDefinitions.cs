using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using TechTalk.SpecFlow;
using Network = OpenQA.Selenium.DevTools.V89.Network;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    internal class WebStepsDefinitions
    {
        private readonly DriverConfiguration config;
        private readonly IWebDriver driver;

        public WebStepsDefinitions(DriverConfiguration configuration)
        {
            config = configuration;
            driver = configuration.WebDriver;
        }

        [Given]
        public void GivenINavigateTo_P0(string p0)
        {
            //Experiment with intercepting requests
            //config.devToolsSession.Network.SetBlockedURLs(new Network.SetBlockedURLsCommandSettings()
            //{
            //    Urls = new string[] { "*://*/*.css", "*://*/*.jpg", "*://*/*.png", "*://*/*.svg" }
            //});
            driver.Navigate().GoToUrl(p0);
        }
    }
}