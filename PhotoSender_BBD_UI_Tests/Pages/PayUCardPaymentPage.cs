using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IPayUCardPaymentPage
    {
        PayUPaymentSummaryPage ClickSubmitButton();
        PayUCardPaymentPage FillInCardPaymentDetails((string cardNumber, string expireDate, string cvvNumber, string nameAndSurname, string email) cardDetails);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class PayUCardPaymentPage : BasePage, IPayUCardPaymentPage
    {
        private IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetCardNumberTextFieldElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.cardNumberTextField);

            return GetElement(PayUPageControls.cardNumberTextField);

        }

        private IWebElement GetCVVTextFielElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.cvvTextField);

            return GetElement(PayUPageControls.cvvTextField);

        }

        private IWebElement GetNameTextFieldElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.nameTextField);

            return GetElement(PayUPageControls.nameTextField);

        }

        private IWebElement GetEmailTextFieldElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.emailTextField);

            return GetElement(PayUPageControls.emailTextField);
        }

        private IWebElement GetSubmitButtonElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.submitButton);

            return GetElement(PayUPageControls.submitButton);
        }

        private IWebElement GetExpiresToTextFieldElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PayUPageControls.expireToDate);

            return GetElement(PayUPageControls.expireToDate);
        }

        private void EnterCardNumber(string cardNumber)
        {
            GetCardNumberTextFieldElement().SendKeys(cardNumber);
        }

        private void EnterExpireToDate(string expireDate)
        {
            GetExpiresToTextFieldElement().SendKeys(expireDate);
        }
        private void EnterCvvNumber(string cvvNumber)
        {
            GetCVVTextFielElement().SendKeys(cvvNumber);
        }

        private void EnterNameAndSurname(string nameAndSuranme)
        {
            GetNameTextFieldElement().SendKeys(nameAndSuranme);
        }

        private void EnterEmail(string email)
        {
            GetEmailTextFieldElement().SendKeys(email);
        }

        public PayUPaymentSummaryPage ClickSubmitButton()
        {
            GetSubmitButtonElement().Click();

            return SwitchContextTo<PayUPaymentSummaryPage>();
        }

        public PayUCardPaymentPage FillInCardPaymentDetails((string cardNumber, string expireDate, string cvvNumber, string nameAndSurname, string email) cardDetails)
        {
            EnterCardNumber(cardDetails.cardNumber);
            EnterExpireToDate(cardDetails.expireDate);
            EnterCvvNumber(cardDetails.cvvNumber);
            EnterNameAndSurname(cardDetails.nameAndSurname);
            EnterEmail(cardDetails.email);

            return this;
        }


    }
}
