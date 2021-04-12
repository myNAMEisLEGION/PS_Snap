using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSender_BBD_UI_Tests.Pages;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using TechTalk.SpecFlow;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public class OrderWithPayUSteps
    {
        private readonly MainWorkflow app;

            public OrderWithPayUSteps (MainWorkflow mainWorkflow)
            {
                app = mainWorkflow;
            }

            [When(@"Completing stages")]
            public void WhenCompletingStages()
            {
                app
                    .CompletePhotoSelectionStage()
                    .CompleteParametersStage(1)
                    .CompleteCroppingStage()
                    .CompleteDeliveryStage(Delivery.FedEX, deliveryAddressName:"Dom2", invoiceAddressName: "Dom")
                    .CompletePaymentStage(PaymentMethod.PayU);
            }

            [When(@"Completing PayU payment")]
            public void WhenCompletingPayUPayment()
            {
                app
                    .CompleteSummaryStage(PayUPageControls.sandboxCardDetails)
                    .CompleteOrderCompletedStage()
                    .NavigateToOrdersPage()
                    .CheckIfCreatedOrderExist();


            }

    }
}
