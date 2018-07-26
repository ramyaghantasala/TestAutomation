using System;
using JustEatRamyaInterview.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace JustEatRamyaInterview.StepDefinitions
{
    [Binding]
    public class FindRestaurantsSteps
    {
        private static RemoteWebDriver driver;
        private FindRestaurantsPage findRestaurantsPage;
        private SearchResultsPage searchResultsPage;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Given("I want food in (.*)")]
        public void IWantFoodIn(string postcode)
        {
            findRestaurantsPage = new FindRestaurantsPage(driver);
            driver.Navigate().GoToUrl("http://www.just-eat.co.uk/");
            findRestaurantsPage = findRestaurantsPage.EnterPostcode(postcode);
        }

        [When("I search for restaurants")]
        public void ISearchForRestaurants()
        {
            searchResultsPage = findRestaurantsPage.SearchRestaurants();
            Console.WriteLine("Step");
        }

        [Then("I should see some restaurants in (.*)")]
        public void ThenTheResultShouldBe(string postcode)
        {
            string count = searchResultsPage.GetNumberOfSearchResults();
            Assert.IsTrue(Int64.Parse(count) > 0,"There are no restaurants in the area: "+postcode);

            string searchText = searchResultsPage.GetSearchresultsText();
            Assert.IsTrue(searchText.Contains(postcode),"Search Results are not for postcode: "+postcode);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
