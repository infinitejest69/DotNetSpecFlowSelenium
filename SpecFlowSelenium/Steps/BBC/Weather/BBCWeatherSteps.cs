using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.Weather;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class BBCWeatherSteps
    {
        readonly DriverConfiguration config;
        readonly IWebDriver driver;
        readonly WeatherHomePage weatherHomePage;

        public BBCWeatherSteps(DriverConfiguration configuration)
        {
            config = configuration;
            driver = configuration.WebDriver;
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
