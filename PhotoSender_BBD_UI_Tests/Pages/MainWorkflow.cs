using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IMainWorkflow
    {
        T CompleteLoginStage<T>(string username, string password);
        MainWorkflow CompleteLoginStage(string username, string password);
        MainWorkflow LoginToClientLabFromAdminLab(string username, string password);
        MainWorkflow LoginToClientLab(string username, string password);
        MainWorkflow SetLabLanguageTo();
        MainWorkflow NavigateToMyLabAdmin();
        OrdersPage NavigateToOrdersPage();
        MainWorkflow CompletePhotoSelectionStage();
        MainWorkflow CompleteParametersStage(int selectFormatOption=0);
        MainWorkflow CompleteCroppingStage();
        MainWorkflow CompleteDeliveryStage(Delivery delivery, string deliveryAddressName, string pickupPointAddressName = null, string invoiceAddressName = null);
        MainWorkflow CompletePaymentStage(PaymentMethod payment);
        MainWorkflow CompleteSummaryStage((string cardNumber, string expireDate, string cvvNumber, string nameAndSurname, string email) cardDetails);
        MainWorkflow CompleteOrderCompletedStage();
        UserLabOrderPage NavigateToClientOrdersPage();
        TPage SwitchContextTo<TPage>();
    }

    public class MainWorkflow : BasePage, IMainWorkflow
    {
        private IWebDriver _driver;
        private ILoginPage _loginPage;
        private IPhotoSelectionPage _photoSelectionPage;
        private IParametersPage _parametersPage;
        private IOrderCompletedPage _orderCompletedPage;
        private IOverviewPage _overviewPage;
        private ISummaryPage _summaryPage;
        private ILabClientWelcome _labClientWelcome;
        private ITopMenuUserLab _topMenuUserLab;
        private ICroppingPage _croppingPage;
        private IDeliveryPage _deliveryPage;
        private IPaymentPage _paymentPage;
        private IPayUPage _payUPage;

        public MainWorkflow
        (
            //IWebDriver driver,
            ILoginPage loginPage,
            IPhotoSelectionPage photoSelectionPage,
            IParametersPage parametersPage,
            IOrderCompletedPage orderCompletedPage,
            IOverviewPage overviewPage,
            ISummaryPage summaryPage,
            ILabClientWelcome labClientWelcome,
            ITopMenuUserLab topMenuUserLab,
            ICroppingPage croppingPage,
            IDeliveryPage deliveryPage,
            IPaymentPage paymentPage,
            IPayUPage payUPage
            )

        {
            //_driver = driver;
            _loginPage = loginPage;
            _photoSelectionPage = photoSelectionPage;
            _parametersPage = parametersPage;
            _orderCompletedPage = orderCompletedPage;
            _overviewPage = overviewPage;
            _summaryPage = summaryPage;
            _labClientWelcome = labClientWelcome;
            _topMenuUserLab = topMenuUserLab;
            _croppingPage = croppingPage;
            _deliveryPage = deliveryPage;
            _paymentPage = paymentPage;
            _payUPage = payUPage;
        }
        private const string ENGLISH= "polski";
        #region LoginPage
        public virtual T CompleteLoginStage<T>(string username, string password)
        {
            _loginPage
                .LogInToApplication(username, password)
                .ClickSubmitButton();

            return SwitchContextTo<T>();
        }

        public MainWorkflow CompleteLoginStage(string username, string password) 
        {
            WaitForPageToBeLoaded();
            _loginPage
                .LogInToApplication(username, password)
                .ClickSubmitButton();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return this;
        }

        #endregion

        public MainWorkflow LoginToClientLabFromAdminLab(string username, string password)
        {
            _overviewPage
                .ClickMyLabLink()
                .ClickBeginOrderButton()
                .EnterCredentialsLabClientLoginPage()
                .ClickLogInButton();

            return this;
        }

        public MainWorkflow LoginToClientLab(string username, string password)
        {
            _labClientWelcome
                .ClickBeginOrderButton()
                .EnterCredentialsLabClientLoginPage(username, password)
                .ClickLogInButton();

            return this;
        }

        #region LabClient


        #endregion
        public MainWorkflow SetLabLanguageTo()
        {
            var page =_overviewPage.NavigateToAccountSettings();
            WaitForPageToBeLoaded();
            string language= page.GetLabAccountLanguage().Text.ToLower();

            if (language == ENGLISH)
            {
                page
                    .ClickLabAccountEditButton()
                    .ClickLabAccountLanguageDropDOwnBreadCrumb()
                    .ClickLabAccountLanguageDropDownPL()
                    .ClickLanguageDropDownSaveButton()
                    .ClickLanguageDropDownCloseButton();

                Thread.Sleep(TimeSpan.FromSeconds(5));
                Assert.AreEqual("Polski", page.GetLabAccountLanguage().Text);
                _driver.Navigate().Back();
            }
            return this;
        }
        public MainWorkflow NavigateToMyLabAdmin()
        {
            DriverContext.Driver.FindElement(By.XPath("//div[@class='main-menu-element'][1]/a[@class='menu-link']")).Click();
            return this;
        }
        public OrdersPage NavigateToOrdersPage()
        {
            _topMenuUserLab.ClickOrderButton(); 
            WaitForPageToBeLoaded();

            return SwitchContextTo<OrdersPage>();
        }


        public MainWorkflow CompletePhotoSelectionStage()
        {
            _photoSelectionPage
                .SwitchContextTo<PhotoSelectionPage>()
                .UploadPictures()
                .ClickNextButton();

            return this;
        }
        public MainWorkflow CompleteParametersStage(int selectFormatOption=0)
        {
            
            WaitForPageToBeLoaded();
            _parametersPage
                .SelectOptionFromFormatDropdown(selectFormatOption)
                .ClickApplyToAllButton()
                .FixMinimalQuantityIfRequired()
                .ClickNextButton();

            return this;
        }

        public MainWorkflow CompleteCroppingStage()
        {
            WaitForPageToBeLoaded();
           _croppingPage
                .ClickNextButtonElementAndAcceptQualityAlert();
            
            return this;
        }

        public MainWorkflow CompleteDeliveryStage(Delivery delivery, string deliveryAddressName, string pickupPointAddressName = null, string invoiceAddressName = null)
        {
            WaitForPageToBeLoaded();
            _deliveryPage
                .SelectDeliveryMethod(delivery)
                .SelectAddressesForDelivery(deliveryAddressName, pickupPointAddressName, invoiceAddressName)
                .ClickNextButton();

            return this;
        }

        public MainWorkflow CompletePaymentStage(PaymentMethod payment)
        {
            WaitForPageToBeLoaded();
            _paymentPage
                .SelectPaymentMethod(payment)
                .ClickNextPageButton();

            return this;
        }

        public MainWorkflow CompleteSummaryStage((string cardNumber, string expireDate, string cvvNumber, string nameAndSurname, string email) cardDetails)
        {
            
            WaitForPageToBeLoaded();
            _summaryPage
                .CheckIfAllPhotosAreAdded()
                .ClickNextButton();
            if (Storage.PaymentMethod == "PayU")
            {
                _payUPage
                    .SwitchContextTo<PayUPage>()
                    .SelectCardPayment()
                    .FillInCardPaymentDetails(cardDetails)
                    .ClickSubmitButton()
                    .ClickCloseAndBackButton();
            }
            return this;
        }

        public MainWorkflow CompleteOrderCompletedStage()
        {
            WaitForPageToBeLoaded();
            _orderCompletedPage
                .StoreOrderNumber()
                .ClickNextButton();

            return this;
        }

        public UserLabOrderPage NavigateToClientOrdersPage()
        {
            _topMenuUserLab
                .ClickOrderButton()
                .WaitForPageToBeLoaded();

            return SwitchContextTo<UserLabOrderPage>();
        }
    }
}
