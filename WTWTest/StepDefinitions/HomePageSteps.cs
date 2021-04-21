using NUnit.Framework;
using TechTalk.SpecFlow;
using WTWTest.ComponentHelper;
using WTWTest.Configuration;
using WTWTest.Pages;

namespace WTWTest.StepDefinitions
{
    [Binding]
    public sealed class HomePageSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have navigated to the WTW Home Page")]
        public void GivenIHaveNavigatedToTheWTWHomePage()
        {
            ObjectRepository.homePage = new HomePage(ObjectRepository.Driver);
            NavigationHelper.NavigateToUrl(WebsiteConfigSection.GetWebsiteUrl());
        }

        [Given(@"I have accepted all cookies")]
        public void GivenIHaveAcceptedAllCookies()
        {
            ObjectRepository.homePage.AcceptCookie();
        }

        [Given(@"I validate I am on the Global site '(.*)'")]
        public void GivenIValidateIAmOnTheGlobalSite(string locationLang)
        {
            string locLang = ObjectRepository.homePage.GetLocationLanguage();
            if (!locLang.Contains(locationLang))
                if (locationLang == "GB | EN")
                    ObjectRepository.homePage.ChangeLocation("Europe", "United Kingdom", "English");
        }        

        [When(@"I search for the word '(.*)' using the search box")]
        public void WhenISearchForTheWordUsingTheSearchBox(string searchText)
        {
            ObjectRepository.searchResultsPage = ObjectRepository.homePage.SearchText(searchText);
        }

        [Then(@"I should navigate to the result page")]
        public void ThenIShouldNavigateToTheResultPage()
        {
            Assert.AreEqual("Search - Willis Towers Watson", ObjectRepository.searchResultsPage.Title, "Navigation to Results Page failed");
        }

    }
}
