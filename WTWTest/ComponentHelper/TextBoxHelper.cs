using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WTWTest.ComponentHelper
{
    public class TextBoxHelper
    {
        public static void TypeInTextBox(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}
