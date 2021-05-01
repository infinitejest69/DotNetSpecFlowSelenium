using BoDi;
using SpecFlowSelenium.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    class Hooks
    {

        private readonly IObjectContainer objectContainer;

        private static WebConfiguration configuration;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario("web")]
        public void createBrowser()
        {
            configuration = new WebConfiguration();
            objectContainer.RegisterInstanceAs<WebConfiguration>(configuration);
        }

        [AfterScenario("web")]
        public static void closeBrowser()
        {
            configuration.GetWebDriver().Dispose();
        }


    }
}
