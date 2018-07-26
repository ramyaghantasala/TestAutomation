using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace JustEatRamyaInterview.PageObjects
{
    public class FindRestaurantsPage
    {
        private RemoteWebDriver driver;

        public FindRestaurantsPage(RemoteWebDriver _driver)
        {
            driver = _driver;
        }

        IWebElement txtPostcode => driver.FindElementById("postcode");
        IWebElement btnSubmit => driver.FindElementByCssSelector("button[class='o-btn o-btn--primary']");

        public FindRestaurantsPage EnterPostcode(string postcode)
        {
            txtPostcode.Clear();
            txtPostcode.SendKeys(postcode);
            return new FindRestaurantsPage(driver);
        }

        public SearchResultsPage SearchRestaurants()
        {
            btnSubmit.Submit();
            return new SearchResultsPage(driver);
        }
    }
}
