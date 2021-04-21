using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using WTWTest.Configuration;

namespace WTWTest.ComponentHelper
{
    public class GenericHelper
    {
        public static string TakeScreenshot(string filename)
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            
            var currentPath = Environment.CurrentDirectory;
            var finalpth = currentPath + Path.DirectorySeparatorChar + filename +
                           DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            var localpath = new Uri(finalpth).LocalPath;
            screen.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        public static string CreateFolder(string filename)
        {
            var currentPath = Environment.CurrentDirectory;
            var parentPath = Path.GetFullPath(Path.Combine(currentPath, "../../../../"));
            var finalPath = (parentPath + Path.DirectorySeparatorChar + filename +
                           DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt"));
            Directory.CreateDirectory(finalPath);
            return finalPath;
        }

        public static IWebElement WaitForWebElementExistsInPage(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Exception occured because of " + locator);
                throw;
            }
        }

        public static IWebElement WaitForWebElementClickableInPage(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Exception occured because of " + locator);
                throw;
            }
        }

        public static ReadOnlyCollection<IWebElement> WaitForWebElementsInPage(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Exception occured because of " + locator);
                throw;
            }
        }

        public static bool IsElementPresent(By Locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(1));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(Locator));
            }
            catch (Exception)
            {                
                return false;
            }
            return true;
        }
    
    }
}
