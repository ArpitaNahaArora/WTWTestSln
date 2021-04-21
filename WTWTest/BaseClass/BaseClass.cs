using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using WebDriverManager;

namespace WTWTest.BaseClass
{
    public class BaseClass
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            options.AddArguments("enable-automation");
            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--disable-browser-side-navigation");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--dns-prefetch-disable");
            options.AddArguments("--disable-gpu");
            options.AddArguments("enable-features=NetworkServiceInProcess");
            options.AddArguments("disable-features=NetworkService");
            return options;
        }

        public static IWebDriver GetChromeDriver()

        {
            string driverVersion = TestExecutionHelper.ChromeDriverVersionHelper.GetDriverVersion();
            new DriverManager().SetUpDriver(
                "https://chromedriver.storage.googleapis.com/" + driverVersion + "/chromedriver_win32.zip",
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "chromedriver.exe"),
                "chromedriver.exe");

            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), GetChromeOptions(), TimeSpan.FromSeconds(30));
            return driver;
        }
    }
}
