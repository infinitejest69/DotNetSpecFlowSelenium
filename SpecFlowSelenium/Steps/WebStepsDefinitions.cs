using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class WebStepsDefinitions
    {
        WebConfiguration config;
        IWebDriver driver;
        public WebStepsDefinitions(WebConfiguration configuration)
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
