using OpenQA.Selenium;
using WTWTest.BaseClass;
using WTWTest.ComponentHelper;

namespace WTWTest.Pages
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        private IWebElement SearchBtn
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//button/span[contains(text(),'Search')]")); }
        }

        private IWebElement SearchTextBox
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//input[@role='searchbox']")); }
        }

        private IWebElement Searchbox
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//a[@role='button' and @aria-label='Search']")); }
        }

        public SearchResultsPage SearchText(string searchText)
        {
            SearchBtn.Click();
            TextBoxHelper.TypeInTextBox(SearchTextBox, searchText);
            Searchbox.Click();
            return new SearchResultsPage(driver);
        }
    }

}
