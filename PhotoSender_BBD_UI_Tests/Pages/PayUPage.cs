using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IPayUPage
    {
        PayUCardPaymentPage SelectCardPayment();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class PayUPage : BasePage, IPayUPage
    {
        private IWebDriver _driver = DriverContext.Driver;


        private IWebElement GetCardPaymentButton()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.cardPaymentButton);

            return GetElement(PayUPageControls.cardPaymentButton);
        }


        private void ClickCardPaymentButton()
        {
            _driver.FluentWaitForElementToBeClickable(PayUPageControls.cardPaymentButton);
            GetCardPaymentButton().Click();
        }

        public PayUCardPaymentPage SelectCardPayment()
        {
            ClickCardPaymentButton();

            return SwitchContextTo<PayUCardPaymentPage>();
        }

        



    }
}
