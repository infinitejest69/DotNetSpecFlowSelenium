using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowSelenium.PageObjects.BBC.Weather;
using FluentAssertions;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class BBCWeatherSteps
    {

        WebConfiguration config;
        IWebDriver driver;
        WeatherHomePage weatherHomePage;

        public BBCWeatherSteps(WebConfiguration configuration)
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
