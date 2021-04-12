using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dynamitey.DynamicObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IUserLabOrderPage
    {
        string GetTextOrderNumberOrdersPage();
        string GetTextOrderCreatedDateOrderPage();
        UserLabOrderPage CheckIfCreatedOrderExist(int orderNumber = 0, bool useStoredNumber = false);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class UserLabOrderPage : BasePage, IUserLabOrderPage
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
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var orderXpath = DriverContext.Driver.FindElement(By.XPath(xpath)).Text;
            Assert.AreEqual(orderNumber, Int32.Parse(orderXpath));
            return xpath;
        }


        private (string xpathOrderNumber, string xpathOrderCreationDate, string xpathLastUpdateDate, string xpathOrderValue, string xpathOrderCurrency, string xpathOrderStatus) OrderDetailsXpathBuilder(int orderNumber)
        {
            string baseXpath = OrderXpathBuilder(orderNumber);
            (string xpathOrderNumber, string xpathOrderCreationDate, string xpathLastUpdateDate, string xpathOrderValue, string xpathOrderCurrency, string xpathOrderStatus) xpathTuple;

            xpathTuple.xpathOrderNumber = baseXpath;
            xpathTuple.xpathOrderCreationDate = baseXpath + "//following-sibling::div[1]";
            xpathTuple.xpathLastUpdateDate = baseXpath + "//following-sibling::div[2]";
            xpathTuple.xpathOrderStatus = baseXpath + "//following-sibling::div[4]//span";
            xpathTuple.xpathOrderValue = baseXpath + "//following-sibling::div[3]//div[@class='price']/div[1]";
            xpathTuple.xpathOrderCurrency = baseXpath + "//following-sibling::div[3]//div[@class='price']//span";

            return xpathTuple;
        }

        public UserLabOrderPage CheckIfCreatedOrderExist(int orderNumber = 0, bool useStoredNumber = false)
         {
            _driver.FluentWaitForElementToBeDisplayed(OrdersPageControls.pageTitle);
            if (useStoredNumber != false)
            {
                var xpath = OrderDetailsXpathBuilder(Storage.OrderNumber).xpathOrderNumber;
                var xpathnum = GetElement(xpath).Text;
                Assert.AreEqual(Storage.OrderNumber, Int32.Parse(xpathnum));
            }
            else
            {
                var xpath = OrderDetailsXpathBuilder(orderNumber).xpathOrderNumber;
                Assert.AreEqual(orderNumber, GetElementText(xpath));
            }

            return this;
        }




    }
}
