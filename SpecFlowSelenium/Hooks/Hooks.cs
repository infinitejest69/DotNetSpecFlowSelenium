using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    class Hooks
    {

        WebConfiguration configuration;
        IWebDriver driver;

        public Hooks(WebConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BeforeScenario("web")]
        public void createBrowser()
        {
            driver = configuration.GetWebDriver();
        }        

        [AfterScenario("web")]
        public void closeBrowser()
        {
            driver.Dispose();
            driver.Close();
        }


    }
}
