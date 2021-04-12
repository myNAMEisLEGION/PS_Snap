using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IPaymentPage
    {
        SummaryPage ClickNextPageButton();
        PaymentPage SelectPaymentMethod(PaymentMethod paymentMethod);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class PaymentPage : BasePage, IPaymentPage
    {
        private readonly IWebDriver _driver = DriverContext.Driver;

        private string PaymentMethodXpathBuilder(PaymentMethod paymentMethod)
        {

            switch (paymentMethod)
            {
                case PaymentMethod.PayU:
                    return PaymentPageControls.paymentPayU;
                    break;
                case PaymentMethod.PrzelewBankowy:
                    return PaymentPageControls.paymentPrzelewBankowy;
                    break;
                case PaymentMethod.KartaPrzyDostawie:
                    return PaymentPageControls.paymentKartaPrzyDostawie;
                    break;
                case PaymentMethod.GotowkaPrzyDostawie:
                    return PaymentPageControls.paymentKartaPrzyDostawie;
                    break;
                default: return PaymentPageControls.paymentPrzelewBankowy;
            }
        }

        private IWebElement GetNextButtonElement()
        {
            return GetElement(PaymentPageControls.nextButton);
        }

        public SummaryPage ClickNextPageButton()
        {
            _driver.FluentWaitForElementToBeClickable(PaymentPageControls.nextButton);
            GetNextButtonElement().Click();

            return SwitchContextTo<SummaryPage>();
        }


        private IWebElement GetPaymentMethod(PaymentMethod paymentMethod)
        {
            string xpath = PaymentMethodXpathBuilder(paymentMethod);
            _driver.FluentWaitForElementToBeDisplayed(xpath);

            return GetElement(xpath);
        }

        public PaymentPage SelectPaymentMethod(PaymentMethod paymentMethod)
        {
            _driver.FluentWaitForElementToBeClickable(PaymentMethodXpathBuilder(paymentMethod));
            GetPaymentMethod(paymentMethod).Click();
            Storage.PaymentMethod = paymentMethod.ToString();
            return this;
        }
    }

}

