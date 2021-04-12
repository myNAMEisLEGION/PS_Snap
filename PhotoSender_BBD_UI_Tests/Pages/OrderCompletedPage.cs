using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IOrderCompletedPage
    {
        LabClientWelcome ClickNextButton();
        string GetOrderCompletedMessageText();
        string GetLabMessageTest();
        int GetOrderNumber();
        OrderCompletedPage StoreOrderNumber();
        bool CheckIfCompleteOrderMessageIsDisplayed();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class OrderCompletedPage : BasePage, IOrderCompletedPage
    {
        private IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetLabMessageElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.labMessage);

            return GetElement(OrderCompletedControls.labMessage);
        }

        private IWebElement GetOrderNumberElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.orderNumber);

            return GetElement(OrderCompletedControls.orderNumber);
        }

        private IWebElement GetOrderCompletedElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.orderCompletedMessage);

            return GetElement(OrderCompletedControls.orderCompletedMessage);
        }

        private IWebElement GetNextButtonElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.nextButton);

            return GetElement(OrderCompletedControls.nextButton);
        }

        public LabClientWelcome ClickNextButton()
        {
            _driver.FluentWaitForElementToBeClickable(OrderCompletedControls.nextButton);
            GetNextButtonElement().Click();

            return SwitchContextTo<LabClientWelcome>();
        }
        public string GetOrderCompletedMessageText()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.orderCompletedMessage);

            return GetOrderCompletedElement().Text;
        }
        public string GetLabMessageTest()
        {
            return GetLabMessageElement().Text;
        }

        public int GetOrderNumber()
        {
           return int.Parse(GetOrderNumberElement().Text);
        }

        public OrderCompletedPage StoreOrderNumber()
        {
            _driver.FluentWaitForElementToBeDisplayed(OrderCompletedControls.labMessage);
            Storage.OrderNumber = GetOrderNumber();

            return this;
        }
        
        public bool CheckIfCompleteOrderMessageIsDisplayed()
        {
            try
            {
                string message = _driver.FindElement(By.XPath(OrderCompletedControls.completeOrderMessage)).Text;

                Assert.AreEqual(OrderCompletedControls.completeOrderMessageTextPL, message);

                return true;  
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
