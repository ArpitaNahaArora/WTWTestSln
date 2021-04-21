using OpenQA.Selenium;
using WTWTest.ComponentHelper;

namespace WTWTest.BaseClass
{
    public class PageBase
    {
        private readonly IWebDriver driver;
        public string continentName;
        public string countryName;
        public string lang;

        protected PageBase(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        private IWebElement CookieBtn
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//a[.='Agree and Proceed']")); }
        }

        private IWebElement LocationSelector
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//button[@aria-controls='country-selector']")); }
        }

        private IWebElement LocationSelectorDropdown
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//i[@data-eventcategory='Navigation - Country Site']")); }
        }

        private IWebElement CountryMenuDropdown
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//span[.='"+continentName+"']/ancestor::span/following-sibling::i[.='arrow_drop_down']")); }
        }

        private IWebElement CountryLangSelector
        {
            get { return GenericHelper.WaitForWebElementClickableInPage(By.XPath("//a[@data-eventlabel='Country: "+countryName+"  | Click Text: "+lang+"']")); }
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public void AcceptCookie()
        {
            driver.SwitchTo().Frame(1);
            CookieBtn.Click();
        }

        public string GetLocationLanguage()
        {
            return LocationSelector.Text;            
        }

        public void ChangeLocation(string continent, string country, string language)
        {
            continentName = continent;
            countryName = country;
            lang = language;

            LocationSelectorDropdown.Click();
            CountryMenuDropdown.Click();
            CountryLangSelector.Click();
        }
    }
}
