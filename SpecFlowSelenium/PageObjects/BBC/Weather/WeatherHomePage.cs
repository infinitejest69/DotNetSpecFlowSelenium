using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using System;


namespace SpecFlowSelenium.PageObjects.BBC.Weather
{
    public class WeatherHomePage
    {
        private IWebDriver Driver;
        public string PageUrl { get; } = "https://www.bbc.co.uk/weather";


        [FindsBy(How = How.Id, Using = "ls-c-search__input-label")]
        [CacheLookup]
        public IWebElement locationSearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@type='submit']")]
        [CacheLookup]
        public IWebElement submitLocationButton { get; set; }

        [FindsBy(How = How.Id, Using = "wr-location-name-id")]
        [CacheLookup]
        public IWebElement locationTitle { get; set; }

        public WeatherHomePage(IWebDriver driver)
        {
            this.Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        public void inputLocation(string location)
        {
            locationSearchBar.SendKeys(location);
        }

        public void clickSubmit()
        {
            submitLocationButton.Click();
        }

        public String getLocationText()
        {
            return locationTitle.Text;
        }
    }
}
