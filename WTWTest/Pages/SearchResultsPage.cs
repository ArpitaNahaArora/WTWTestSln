using OpenQA.Selenium;
using System.Collections.Generic;
using WTWTest.BaseClass;
using WTWTest.ComponentHelper;

namespace WTWTest.Pages
{
    public class SearchResultsPage : PageBase
    {
        private IWebDriver driver;
        public string criteria;
        public string facetName;

        public SearchResultsPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        private IWebElement SelectedCriteria
        {
            get { return GenericHelper.WaitForWebElementExistsInPage(By.XPath("//span[contains(@class, 'coveo-selected')]")); }
        }

        private IWebElement SortCriteria
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//span[@aria-label='Sort results by " + criteria + "']")); }
        }

        private IWebElement ShowMoreIndustryFacets
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//div[@aria-label='Show more results for Industry facet']")); }
        }

        private IWebElement RefineFacet
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//span[@title='" + facetName + "']")); }
        }

        private IWebElement FilterCriteria
        {
            get { return GenericHelper.WaitForWebElementExistsInPage(By.ClassName("coveo-facet-breadcrumb-caption")); }
        }

        public string CheckSortCriteria()
        {
            return SelectedCriteria.Text;
        }

        public IList<IWebElement> ListOfSearchResults
        {
            get { return GenericHelper.WaitForWebElementsInPage(By.CssSelector(".CoveoResultLink.wtw-listing-result-title")); }
        }

        public void SortResultsUsingCriteria(string sortCriteria)
        {
            criteria = sortCriteria;
            SortCriteria.Click();
        }

        public void RefineSearch(string filterCriteria)
        {
            facetName = filterCriteria;
            while (!GenericHelper.IsElementPresent(By.XPath("//span[@title='" + filterCriteria + "']")))
            {
                GenericHelper.WaitForWebElementClickableInPage(By.XPath("//div[@aria-label='Show more results for Industry facet']")).Click();
            }
            RefineFacet.Click();
        }

        public bool CheckRefinedResults(string filterCriteria)
        {
            return (FilterCriteria.Text == filterCriteria);
        }

        public List<string> GetResultTitlesList()
        {
            var listOfTitles = new List<string>() { };
            foreach (var result in ListOfSearchResults)
            {
                listOfTitles.Add(result.Text);
            }
            return listOfTitles;
        }
    }
}
