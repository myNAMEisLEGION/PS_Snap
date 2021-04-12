using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using TechTalk.SpecFlow;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public class OrderWithDiscountSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private MainWorkflow app;

        public OrderWithDiscountSteps(MainWorkflow mainworkflow)
        {
            app = mainworkflow;
        }


        [When(@"User reach summary stage add discount")]
        public void WhenUserReachSummaryStageAddDiscount()
        {
            app
                .CompletePhotoSelectionStage()
                .CompleteParametersStage(1)
                .CompleteCroppingStage()
                .CompleteDeliveryStage(Delivery.FedEX, deliveryAddressName: "Dom2", invoiceAddressName: "Dom")
                .CompletePaymentStage(PaymentMethod.PrzelewBankowy);
        }

        [When(@"verify if price is correctly calculated")]
        public void WhenVerifyIfPriceIsCorrectlyCalculated()
        {
            app
                .WaitForPageToBeLoaded<SummaryPage>()
                .StoreOrderTotalValue()
                .AddDiscount(SummaryPageControls.discount50.discountName)
                .CheckIfTotalValueIsCorrectlyCalculated()
                .ClickNextButton();

        }

        [Then(@"Order is displayed in order list with discounted price")]
        public void ThenOrderIsDisplayedInOrderListWithDiscountedPrice()
        {
            app
                .CompleteOrderCompletedStage()
                .NavigateToOrdersPage()
                .CheckIfCreatedOrderExist()
                .CheckIfCreatedOrderTotalValueIsCorrect(Storage.PriceAfterDiscount);
        }

       

    }
}
