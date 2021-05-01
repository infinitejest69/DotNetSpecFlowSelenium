using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.News;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
     class BBCNewsSteps
    {

        WebConfiguration config;
        IWebDriver driver;
        NewsHomePage newsHome;

        public BBCNewsSteps(WebConfiguration configuration)
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
