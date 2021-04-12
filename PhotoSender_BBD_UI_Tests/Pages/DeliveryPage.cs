using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.Network;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IDeliveryPage
    {
        DeliveryPage ClickDeliveryNameTest(string xpath);
        PaymentPage ClickNextButton();
        DeliveryPage ClickInvoiceAddressSwitch();
        DeliveryPage SelectDeliveryMethod(Delivery delivery);
        DeliveryPage SelectAddressesForDelivery(string deliveryAddressName, string pickupPointAddressName = null, string invoiceAddressName = null);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class DeliveryPage : BasePage, IDeliveryPage
    {
        private readonly IWebDriver _driver;
        private IPaymentPage _paymentPage;

        public DeliveryPage(IPaymentPage paymentPage, IWebDriver driver)
        {
            _driver = driver;
            _paymentPage = paymentPage;
        }

        private IWebElement GetDeliveryMethodContainerElement()
        {
            return GetElement(DeliveryPageControls.deliveryMethodContainer);
        }

        private IWebElement GetDeliveryMethodNamElement()
        {
            return GetElement(DeliveryPageControls.deliveryMethodName);
        }

        private void ClickDeliveryMethodContainer()
        {
            GetDeliveryMethodContainerElement().Click();

        }

        public DeliveryPage ClickDeliveryNameTest(string xpath)
        {
            _driver.FluentWaitForElementToBeDisplayed(xpath);
            GetElement(xpath).Click();

            return this;
        }

        private IWebElement GetAddressElement(string addressName)
        {
            string xpath = $"//div[text()='{addressName}']";
            _driver.FluentWaitForElementToBeDisplayed(xpath);

            return GetElement(xpath);
        }

        private DeliveryPage ClickAddressElement(string addressName)
        {
            string xpath = $"//div[text()='{addressName}']";
            _driver.FluentWaitForElementToBeClickable(xpath);
            GetAddressElement(addressName).Click();

            return this;
        }

        private IWebElement GetNextButtonElement()
        {
            return GetElement(DeliveryPageControls.nextButton);
        }

        public PaymentPage ClickNextButton()
        {
            _driver.FluentWaitForElementToBeClickable(DeliveryPageControls.nextButton);
            GetNextButtonElement().Click();

            return SwitchContextTo<PaymentPage>();
        }

        private IWebElement GetInvoiceAddressSwitchElement()
        {
            return GetElement(DeliveryPageControls.invoiceAddressSwitch);
        }

        public DeliveryPage ClickInvoiceAddressSwitch()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _driver.FluentWaitForElementToBeClickable(DeliveryPageControls.invoiceAddressSwitch);
            GetInvoiceAddressSwitchElement().Click();

            return this;
        }


        private string DeliveryMethodXpathBuilder(Delivery selectDelivery)
        {
            switch (selectDelivery)
            {
                case Delivery.PocztaPolskaZaPobraniem:
                {
                    return "//div[contains(text(),'Poczta Polska (za pobraniem)')]";
                }
                case Delivery.DHLZaPobraniem:
                {
                    return "//div[contains(text(),'DHL (za pobraniem)')]";
                }
                case Delivery.FedEX:
                {
                    return "//div[contains(text(),'FedEx')]";
                }
                case Delivery.FedExZapobraniem:
                {
                    return "//div[contains(text(),'FedEx (za pobraniem)')]";
                }

                default: return "//div[contains(text(),'Odbiór osobisty')]";

            }
        }

        public DeliveryPage SelectDeliveryMethod(Delivery delivery)
        {
            string xpath = DeliveryMethodXpathBuilder(delivery);
            if (delivery != Delivery.OdbiórOsobisty)
            {
                Storage.DeliveryPrice = double.Parse(GetElementText(xpath + "/following-sibling::div[2]/div/div[1]"));
            }
            ClickDeliveryNameTest(xpath);

            return this;
        }

        private DeliveryPage SelectDeliveryAddress(string addressName)
        {
            ClickAddressElement(addressName);

            return this;
        }

        public DeliveryPage SelectAddressesForDelivery(string deliveryAddressName, string pickupPointAddressName = null, string invoiceAddressName = null)
        {
            if ((!string.IsNullOrEmpty(pickupPointAddressName)))
            {
                SelectDeliveryMethod(default);
                SelectDeliveryAddress(pickupPointAddressName);
            }

            else SelectDeliveryAddress(deliveryAddressName);

            if ((!string.IsNullOrEmpty(invoiceAddressName)))
            {
                ClickInvoiceAddressSwitch();
                SelectDeliveryAddress(deliveryAddressName);
                SelectDeliveryAddress(invoiceAddressName);
               
            }

            return this;
        }


    }
}
