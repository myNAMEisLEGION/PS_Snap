
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dynamitey;
using PhotoSender_BBD_UI_Tests.Factory;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhotoSender_BBD_UI_Tests.Extensions
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver, TypeOfWait type)
        {
            TimeSpan timeSpan = new TimeSpan();
            switch (type)
            {
                case TypeOfWait.minimumWait:
                    timeSpan = TimeSpan.FromSeconds(10);
                    break;
                case TypeOfWait.mediumWait:
                    timeSpan = TimeSpan.FromSeconds(30);
                    break;
                case TypeOfWait.maximumWait:
                    timeSpan = TimeSpan.FromSeconds(60);
                    break;
                default:
                    break;
            }

            return new WebDriverWait(driver, timeSpan);
        }

        public static void WaitForClickable(this IWebDriver driver, string xpath,
            TypeOfWait type = TypeOfWait.mediumWait)
        {
            driver.Wait(type).Until(x => x.FindElement(By.XPath(xpath)).Displayed);
        }

        public static void WaitForVisible(this IWebDriver driver, string xpath)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public static void FluentWaitForElementToBeClickable(this IWebDriver driver, string xpath, int seconds = 20)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(2);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        public static void FluentWaitForElementToBeDisplayed(this IWebDriver driver, string xpath,int seconds=20)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
            fluentWait.Timeout= TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }
        public static void FluentWaitForElementToExist(this IWebDriver driver, string xpath, int seconds = 20)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
        public static void FluentWaitForElementTextToBePresent(this IWebDriver driver, string xpath, string text, int seconds = 20)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(ExpectedConditions.TextToBePresentInElement((DriverContext.Driver.FindElement(By.XPath(xpath))),text));
        }

    }

 
}