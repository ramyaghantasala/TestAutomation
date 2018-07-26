using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace JustEatRamyaInterview.PageObjects
{
    public class SearchResultsPage
    {
        private RemoteWebDriver driver;

        public SearchResultsPage(RemoteWebDriver _driver)
        {
            driver = _driver;
        }

        IWebElement numberOfResults => driver.FindElementByXPath("//div[contains(@class,'c-serp__header--primary')]//span[@class='c-serp__header--count']");
        IWebElement searchResultsText => driver.FindElementByXPath("//div[contains(@class,'c-serp__header--primary')]//h1");

        public string GetNumberOfSearchResults()
        {
            return numberOfResults.Text;
        }

        public string GetSearchresultsText()
        {
            return searchResultsText.Text;
        }
    }
}
