using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public sealed class CreateNewOrderSteps : BaseStep
    {

        private IMainWorkflow _app;

        public CreateNewOrderSteps()
        {
            _app = InitializeApp().Resolve<IMainWorkflow>();
        }


        [Given(@"I am logged in to application with credentials UserName and Password")]
        public void GivenIAmLoggedInToApplicationWithCredentialsUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            DriverContext.Driver.Navigate().GoToUrl("https://photosender-qa-ui.azurewebsites.net/lab/zxc12");
            _app
                .LoginToClientLab(data.UserName, data.Password);

        }

        [When(@"I am creating new order")]
        public void WhenIAmCreatingNewOrder()
        {
            _app
                .CompletePhotoSelectionStage()
                .CompleteParametersStage(1)
                .CompleteCroppingStage()
                .CompleteDeliveryStage(Delivery.FedEX, deliveryAddressName: "Dom2", invoiceAddressName: "Dom")
                .CompletePaymentStage(PaymentMethod.PrzelewBankowy)
                .CompleteSummaryStage(PayUPageControls.sandboxCardDetails)
                .CompleteOrderCompletedStage();

        }

        [When(@"Completing all stages")]
        public void WhenCompletingAllStages()
        {

        }

        [Then(@"Order is displayed in order list")]
        public void ThenOrderIsDisplayedInOrderList()
        {
           _app
                .NavigateToClientOrdersPage()
                .CheckIfCreatedOrderExist(useStoredNumber: true);
        }

    }
}
