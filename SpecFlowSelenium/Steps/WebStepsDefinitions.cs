using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowSelenium.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class WebStepsDefinitions
    {
        DriverConfiguration config;
        IWebDriver driver;
        public WebStepsDefinitions(DriverConfiguration configuration)
        {
            this.config = configuration;
            driver = configuration.GetWebDriver();
        }

        [Given]
        public void GivenINavigateTo_P0(string p0)
        {
            driver.Navigate().GoToUrl(p0);
        }

    }
}
