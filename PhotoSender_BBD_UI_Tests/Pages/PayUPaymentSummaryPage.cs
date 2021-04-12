using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IPayUPaymentSummaryPage
    {
        string GetSummaryInfoHeaderTest();
        string GetSummaryMessageTest();
        SummaryPage ClickCloseAndBackButton();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class PayUPaymentSummaryPage : BasePage, IPayUPaymentSummaryPage
    {
        private readonly IWebDriver _driver;

        public PayUPaymentSummaryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement GetSummaryInfoHeader()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPaymentSummaryPageControls.summaryInfoHeader);

            return GetElement(PayUPaymentSummaryPageControls.summaryInfoHeader);
        }

        private IWebElement GetSummaryMessageElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPaymentSummaryPageControls.summaryMessage);

            return GetElement(PayUPaymentSummaryPageControls.summaryMessage);
        }

        private IWebElement GetCloseAndBackButton()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPaymentSummaryPageControls.closeAndBackButton);

            return GetElement(PayUPaymentSummaryPageControls.closeAndBackButton);
        }
        public string GetSummaryInfoHeaderTest()
        {
            return GetSummaryInfoHeader().Text;
        }

        public string GetSummaryMessageTest()
        {
            return GetSummaryMessageElement().Text;
        }

        public SummaryPage ClickCloseAndBackButton()
        {
            _driver.FluentWaitForElementToBeClickable(PayUPaymentSummaryPageControls.closeAndBackButton);
            GetCloseAndBackButton().Click();

            return SwitchContextTo<SummaryPage>();
        }
    }
}
