using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ICroppingPage
    {
        DeliveryPage ClickQualityAlertButton();
        DeliveryPage ClickNextButtonElement();
        DeliveryPage ClickNextButtonElementAndAcceptQualityAlert();
        void AcceptQualityAlert();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public  class CroppingPage : BasePage, ICroppingPage
    {
        private readonly IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetNextButtonElement()
        {
            return GetElement(CroppingPageControls.nextButton);
        }

        private IWebElement GetQualityAlertButtonElement()
        {
            return GetElement(CroppingPageControls.qualityAlertPopupButton);
        }

        public DeliveryPage ClickQualityAlertButton()
        {
            _driver.FluentWaitForElementToBeClickable(CroppingPageControls.qualityAlertPopupButton);
            GetQualityAlertButtonElement().Click();

            return SwitchContextTo<DeliveryPage>();

        }
        public DeliveryPage ClickNextButtonElement()
        {
            _driver.FluentWaitForElementToBeClickable(CroppingPageControls.nextButton);
             GetNextButtonElement().Click();

             return SwitchContextTo<DeliveryPage>();
        }


        public DeliveryPage ClickNextButtonElementAndAcceptQualityAlert()
        {
            _driver.FluentWaitForElementToBeClickable(CroppingPageControls.nextButton);
            GetNextButtonElement().Click();
            AcceptQualityAlert();

            return SwitchContextTo<DeliveryPage>();
        }

        private bool CheckIfQualityAlertIsDisplayed()
        {
            try
            {
                _driver.FluentWaitForElementToBeDisplayed(CroppingPageControls.qualityAlertPopup);
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }

        public void AcceptQualityAlert()
        {
            if (CheckIfQualityAlertIsDisplayed() == true)
            {
                ClickQualityAlertButton();
            }
        }
    }
}
