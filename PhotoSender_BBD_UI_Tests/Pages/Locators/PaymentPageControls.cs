using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class PaymentPageControls
    {

        public static readonly string paymentPayU = "//div[text()='PayU']";
        public static readonly string paymentPrzelewBankowy = "//div[text()='Przelew bankowy']";
        public static readonly string paymentKartaPrzyDostawie = "//div[text()='Kartą przy dostawie']";
        public static readonly string paymentGotowkaPrzyDostawie = "//div[text()='Gotówką przy dostawie']";

        public static readonly string nextButton = "//div[@class='continue-button']";

    }
}

public enum PaymentMethod
{
    PayU,
    PrzelewBankowy,
    KartaPrzyDostawie,
    GotowkaPrzyDostawie,

}
