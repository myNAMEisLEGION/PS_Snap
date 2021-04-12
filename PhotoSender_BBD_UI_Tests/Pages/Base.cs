using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Io.Cucumber.Messages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public abstract class Base
    {
        private IWebDriver _driver = DriverContext.Driver;
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
