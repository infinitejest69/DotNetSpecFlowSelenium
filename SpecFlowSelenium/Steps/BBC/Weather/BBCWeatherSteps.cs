using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.Weather;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class BBCWeatherSteps
    {

        DriverConfiguration config;
        IWebDriver driver;
        WeatherHomePage weatherHomePage;

        public BBCWeatherSteps(DriverConfiguration configuration)
        {
            this.config = configuration;
            driver = configuration.GetWebDriver();
            weatherHomePage = new WeatherHomePage(driver);

        }


        [When(@"i input the location ""(.*)""")]
        public void WhenIInputTheLocation(string location)
        {
            weatherHomePage.inputLocation(location);
        }


        [When(@"click search")]
        public void clickSearch()
        {
            weatherHomePage.clickSubmit();
        }

        [Then(@"i see current weather for ""(.*)""")]
        public void iSeeCurrentWeatherFor(string location)
        {

            weatherHomePage.getLocationText().Should().BeEquivalentTo(location);
        }
    }
}
