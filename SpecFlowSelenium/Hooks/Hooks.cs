using Microsoft.Extensions.Configuration;
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

        WebConfiguration configuration = new WebConfiguration();

        public Hooks(WebConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BeforeScenario("web")]
        public void createBrowser()
        {
           Console.WriteLine( configuration.getBrowser());
        }
    }
}
