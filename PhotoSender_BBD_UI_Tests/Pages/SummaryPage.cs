using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using Xunit;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ISummaryPage
    {
        OrderCompletedPage ClickNextButton();
        SummaryPage CheckIfAllPhotosAreAdded();
        SummaryPage StoreOrderTotalValue();
        SummaryPage StoreOrderDiscountedTotalValue();
        SummaryPage CheckIfTotalValueIsCorrectlyCalculated();
        SummaryPage AddDiscount(string discount);
        SummaryPage CheckIfSuccessAlertIsPresent();
        OrderCompletedPage CheckIfOrderIsSuccessfullyProcessed();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class SummaryPage : BasePage, ISummaryPage
    {
        private readonly IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetNextButtonElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(SummaryPageControls.nextButton);

            return GetElement(SummaryPageControls.nextButton);
        }

        private IWebElement GetDiscountTextField()
        {
            return GetElement(SummaryPageControls.discountTextField);
        }

        private IWebElement GetOrderTotalValueElement()
        {
            return GetElement(SummaryPageControls.orderTotalValue);
        }

        private IWebElement GetDiscountSaveButtonElement()
        {
            return GetElement(SummaryPageControls.discountSaveButton);
        }

        private SummaryPage ClickSaveDiscountButton()
        {
            GetDiscountSaveButtonElement().Click();

            return this;
        }
        private SummaryPage EnterTextDiscountField(string discount)
        {
            GetDiscountTextField().SendKeys(discount);

            return this;
        }

        private IWebElement GetAlertError()
        {
            return GetElement(SummaryPageControls.alertError);
        }

        private IWebElement GetAlertSuccess()
        {
            return GetElement(SummaryPageControls.alertSuccess);
        }

        public OrderCompletedPage ClickNextButton()
        {
            _driver.FluentWaitForElementToBeClickable(SummaryPageControls.nextButton);
            GetNextButtonElement().Click();
            CheckIfOrderIsSuccessfullyProcessed();

            return SwitchContextTo<OrderCompletedPage>();
        }
        private IList<IWebElement> GetPhotoContainers()
        {
            _driver.FluentWaitForElementToBeDisplayed(SummaryPageControls.photoContainer);

            return GetElements(SummaryPageControls.photoContainer).ToList();
        }

        public SummaryPage CheckIfAllPhotosAreAdded()
        {
            Storage.PhotoCountSummary = GetPhotoContainers().Count;
            Assert.True(Storage.PhotoCountAdded == Storage.PhotoCountSummary);

            return this;
        }

        public SummaryPage StoreOrderTotalValue()
        {
            Storage.TotalValue = Double.Parse(GetOrderTotalValueElement().Text);

            return this;
        }

        public SummaryPage StoreOrderDiscountedTotalValue()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Storage.PriceAfterDiscount = Double.Parse(GetOrderTotalValueElement().Text);

            return this;
        }

        public SummaryPage CheckIfTotalValueIsCorrectlyCalculated()
        {
            double photoPrice = Storage.TotalValue - Storage.DeliveryPrice;
            double discountValue = photoPrice * (SummaryPageControls.discount50.discountValue / 100);
            double priceAfterDiscount = Math.Round((Storage.TotalValue -discountValue),2); 
            Assert.True(priceAfterDiscount == (Storage.PriceAfterDiscount));

            return this;
        }

        public SummaryPage AddDiscount(string discount)
        {
            EnterTextDiscountField(discount);
            ClickSaveDiscountButton();
            StoreOrderDiscountedTotalValue();

            return this;
        }

        public SummaryPage CheckIfSuccessAlertIsPresent()
        {
            try
            {
                _driver.FindElement(By.XPath(SummaryPageControls.alertSuccess));
            }
            catch (Exception e)
            {
                _driver.FindElement(By.XPath(SummaryPageControls.alertError));
            }

            return this;
        }

        private bool CheckIfProgressBarIsDisplayed()
        {
            try
            {
                _driver.FindElement(By.XPath(SummaryPageControls.progressBarThemed));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public OrderCompletedPage CheckIfOrderIsSuccessfullyProcessed()
        {
            while (CheckIfProgressBarIsDisplayed() == true)
            {
                continue;
            }
            WaitForPageToBeLoaded();
            var page = SwitchContextTo<OrderCompletedPage>();
            page.CheckIfCompleteOrderMessageIsDisplayed();

            return page;
        }
    }
}
