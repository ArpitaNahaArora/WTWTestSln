using System;
using System.Collections.Generic;
using System.Text;
using WTWTest.Configuration;

namespace WTWTest.ComponentHelper
{
    public class NavigationHelper
    {
        public static string NavigateToUrl(string url)
        {
            try
            {
                ObjectRepository.Driver.Navigate().GoToUrl(url);
            }
            catch
            {
                Console.WriteLine("Timeout while loading page" + url);
            }
            return ObjectRepository.Driver.Title;
        }
    }
}
