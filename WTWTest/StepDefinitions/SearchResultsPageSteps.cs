using NUnit.Framework;
using TechTalk.SpecFlow;
using WTWTest.ComponentHelper;
using WTWTest.Configuration;

namespace WTWTest.StepDefinitions
{
    [Binding]
    public sealed class SearchResultsPageSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SearchResultsPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the results should be sorted by '(.*)'")]
        public void ThenTheResultsShouldBeSortedBy(string sortCriteria)
        {
            string selectedCriteria = ObjectRepository.searchResultsPage.CheckSortCriteria();

            if (selectedCriteria != sortCriteria)
                ObjectRepository.searchResultsPage.SortResultsUsingCriteria(sortCriteria);
        }

        [Then(@"I filter the search by '(.*)'")]
        public void ThenIFilterTheSearchBy(string filterCriteria)
        {
            ObjectRepository.searchResultsPage.RefineSearch(filterCriteria);
            bool refineSearchStatus = ObjectRepository.searchResultsPage.CheckRefinedResults(filterCriteria);
            Assert.AreEqual(true, refineSearchStatus, "Search Results not displayed for filter criteria" + filterCriteria);
        }

        [Then(@"the titles of all the result articles are displayed in output")]
        public void ThenTheTitlesOfAllTheResultArticlesAreDisplayedInOutput()
        {
            _scenarioContext.Add("ResultTitles", ObjectRepository.searchResultsPage.GetResultTitlesList());
        }
    }
}
