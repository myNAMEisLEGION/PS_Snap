using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoSender_BBD_UI_Tests.Pages;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using TechTalk.SpecFlow;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public sealed class OrderWithPickUpPointSteps
    {

        private readonly MainWorkflow app;

        public OrderWithPickUpPointSteps(MainWorkflow mainWorkflow)
        {
            app = mainWorkflow;
        }

        [When(@"User reach delivery stage delivery method: Collection in Person and Pickup Point is chosen")]
        public void WhenUserReachDeliveryStageDeliveryMethodCollectionInPersonAndPickupPointIsChosen()
        {
            app
                .CompletePhotoSelectionStage()
                .CompleteParametersStage(1)
                .CompleteCroppingStage()
                .CompleteDeliveryStage(Delivery.OdbiórOsobisty, deliveryAddressName: "Siedizba", invoiceAddressName: "Firma");
        }

        [Then(@"Order is displayed in order list with correct deivery method and pickup point address")]
        public void ThenOrderIsDisplayedInOrderListWithCorrectDeiveryMethodAndPickupPointAddress()
        {
            app
                .CompletePaymentStage(PaymentMethod.PrzelewBankowy)
                .CompleteSummaryStage(PayUPageControls.sandboxCardDetails)
                .CompleteOrderCompletedStage()
                .NavigateToOrdersPage()
                .CheckIfCreatedOrderExist();
        }

    }
}
