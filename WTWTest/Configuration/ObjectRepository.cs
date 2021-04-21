using OpenQA.Selenium;
using WTWTest.Pages;

namespace WTWTest.Configuration
{
    public class ObjectRepository
    {
        public static IWebDriver Driver { get; set; }

        public static HomePage homePage;
        public static SearchResultsPage searchResultsPage;
    }
}
