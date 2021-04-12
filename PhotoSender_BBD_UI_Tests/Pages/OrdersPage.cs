using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dynamitey;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using Shouldly.Configuration;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IOrdersPage
    {
        string GetTextOrderNumberOrdersPage();
        string GetTextOrderCreatedDateOrderPage();
        OrdersPage CheckIfCreatedOrderExist(int orderNumber = 0, bool useStoredNumber = true);
        OrdersPage CheckIfCreatedOrderPaymentStatusChangedTo(string status, int orderNumber = 0, bool useStoredNumber = true);
        OrdersPage CheckIfCreatedOrderTotalValueIsCorrect(double totalValue, int orderNumber = 0, bool useStoredNumber = true);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class OrdersPage : BasePage, IOrdersPage
    {
        private IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetOrderNumberOrdersPage()
        {
            return GetElement(OrdersPageControls.orderNumber);
        }

        private IWebElement GetOrderCreatedDate()
        {
            return GetElement(Controls.createdDateOrderPage);
        }


        public string GetTextOrderNumberOrdersPage()
        {
            return GetOrderNumberOrdersPage().Text;
        }

        public string GetTextOrderCreatedDateOrderPage()
        {
            return GetOrderCreatedDate().Text;
        }


        private string OrderXpathBuilder(int orderNumber)
        {
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(OrdersPageControls.pageTitle);
            //string xpath = $"//div[@class='collapsible-list-row-header']/div[contains(string(), \""+ orderNumber + "\")]";
            string xpath = $"//div[@class='collapsible-list-row-header']/div[contains(string(),'{orderNumber}')]";
            var orderXpath = DriverContext.Driver.FindElement(By.XPath(xpath)).Text;
            Assert.AreEqual(orderNumber.ToString(), orderXpath);
            return xpath;
        }


        private (string xpathOrderNumber, string xpathOrderCreationDate, string xpathLastUpdateDate, string
            xpathOrderValue, string xpathOrderCurrency, string xpathOrderStatus, string xpathPaymentStatus, string xpathOrderPanleExpander) OrderDetailsXpathBuilder(int orderNumber)
        { 
            string baseXpath = OrderXpathBuilder(orderNumber);
            (string xpathOrderNumber, string xpathOrderCreationDate, string xpathLastUpdateDate, string xpathOrderValue,
                string xpathOrderCurrency, string xpathOrderStatus, string xpathPaymentStatus, string
                xpathOrderPanleExpander) xpathTuple;
                
            xpathTuple.xpathOrderNumber = baseXpath;
            xpathTuple.xpathOrderCreationDate = baseXpath + "//following-sibling::div[1]";
            xpathTuple.xpathLastUpdateDate = baseXpath + "//following-sibling::div[2]";
            xpathTuple.xpathOrderStatus = baseXpath + "//following-sibling::div[4]//span";
            xpathTuple.xpathOrderValue = baseXpath + "//following-sibling::div[3]//div[@class='price']/div[1]";
            xpathTuple.xpathOrderCurrency = baseXpath + "//following-sibling::div[3]//div[@class='price']//span";
            xpathTuple.xpathPaymentStatus = baseXpath + "//..//following-sibling::div[@class='collapsible-list-row-content-container']//div[@class='payment-status']/span[2]";
            xpathTuple.xpathOrderPanleExpander = baseXpath + "//following-sibling::div[6]/div";


            return xpathTuple;
        }

        public OrdersPage CheckIfCreatedOrderExist(int orderNumber = 0, bool useStoredNumber = true)
        {
            _driver.FluentWaitForElementToBeDisplayed(OrdersPageControls.pageTitle);
            if (useStoredNumber != false)
            {
                var xpath = OrderDetailsXpathBuilder(Storage.OrderNumber).xpathOrderNumber;
                Assert.AreEqual(Storage.OrderNumber.ToString(), GetElementText(xpath));
            }
            else
            {
                var xpath = OrderDetailsXpathBuilder(orderNumber).xpathOrderNumber;
                Assert.AreEqual(orderNumber, GetElementText(xpath));
            }

            return this;
        }

        public OrdersPage CheckIfCreatedOrderPaymentStatusChangedTo(string status, int orderNumber = 0, bool useStoredNumber = true)
        {
            CheckIfCreatedOrderExist(orderNumber, useStoredNumber);
            var xpath = OrderDetailsXpathBuilder(useStoredNumber == true ? Storage.OrderNumber : orderNumber);
            GetElement(xpath.xpathOrderPanleExpander).Click();
            _driver.FluentWaitForElementToBeDisplayed(xpath.xpathPaymentStatus);
            Assert.AreEqual(status, GetElementText(xpath.xpathPaymentStatus));

            return this;
        }

        public OrdersPage CheckIfCreatedOrderTotalValueIsCorrect(double totalValue, int orderNumber = 0, bool useStoredNumber = true)
        {
            CheckIfCreatedOrderExist(orderNumber, useStoredNumber);
            var xpath = OrderDetailsXpathBuilder(useStoredNumber == true ? Storage.OrderNumber : orderNumber);
            GetElement(xpath.xpathOrderPanleExpander).Click();
            _driver.FluentWaitForElementToBeDisplayed(xpath.xpathOrderValue);
            Assert.AreEqual(totalValue, double.Parse(GetElementText(xpath.xpathOrderValue)));

            return this;
        }
    }
}