using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.News;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class BBCNewsSteps
    {

        DriverConfiguration config;
        RemoteWebDriver driver;
        NewsHomePage newsHome;

        public BBCNewsSteps(DriverConfiguration configuration)
        {
            this.config = configuration;
            driver = configuration.GetWebDriver();
            newsHome = new NewsHomePage(driver);

        }

        [When(@"i click news menu ""(.*)""")]
        public void iCheckNewsFor(string menuItem)
        {
            newsHome.ClickMenuItem(menuItem);
        }

        [Then(@"i see stories for ""(.*)""")]
        public void iSeeStoriesFor(string input)
        {
            newsHome.GetCSectionLinkText(input).Should().Contain(input);
        }
    }
}
