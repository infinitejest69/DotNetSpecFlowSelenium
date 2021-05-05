using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.Sports;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]

    class BBCSportsSteps
    {

        DriverConfiguration config;
        IWebDriver driver;
        SportsHomePage sportsHomePage;

        public BBCSportsSteps(DriverConfiguration configuration)
        {
            this.config = configuration;
            driver = configuration.GetWebDriver();
            sportsHomePage = new SportsHomePage(driver);

        }

        [Then(@"i see current formula 1 driver table")]
        public void iSeeCurrentFormulaDriverTable()
        {

            sportsHomePage.getPageTitle().Should().BeEquivalentTo("FIA Formula 1 Standings");
        }

        [When(@"i click ""(.*)"" from the menu")]
        public void iClickFromTheMenu(string menuItem)
        {
            sportsHomePage.clickMenuItem(menuItem);
        }

        [When(@"i click ""(.*)"" from the submenu")]
        public void iClickFromTheSubmenu(string subMenuItem)
        {
            sportsHomePage.clickSubMenuItem(subMenuItem);
        }
    }
}
