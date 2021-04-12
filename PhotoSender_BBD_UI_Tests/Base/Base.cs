using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;

namespace PhotoSender_BBD_UI_Tests.Base
{
    public abstract class Base
    {
        private IWebDriver _driver = Driver.Driver;
        internal IWebElement GetElement(string xpath)
        {
            try
            {
                _driver.FluentWaitForElementToBeDisplayed(xpath);
                return _driver.FindElement(By.XPath(xpath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal IReadOnlyCollection<IWebElement> GetElements(string xpath)
        {
            try
            {
                return _driver.FindElements(By.XPath(xpath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal string GetElementText(string xpath)
        {
            try
            {
                _driver.FluentWaitForElementToBeDisplayed(xpath);
                return _driver.FindElement(By.XPath(xpath)).Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal SelectElement GetSelectElement(string xpath)
        {
            try
            {
                return new SelectElement(_driver.FindElement(By.XPath(xpath)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal IReadOnlyCollection<string> GetWindowsHandlers()
        {
            var tabs = _driver.WindowHandles;
            return tabs;
        }

        internal void SwitchToTab(int tabnumber = 1)
        {
            var tabs = GetWindowsHandlers().ToList();
            _driver.SwitchTo().Window(tabs[tabnumber]);
        }

    }
}
