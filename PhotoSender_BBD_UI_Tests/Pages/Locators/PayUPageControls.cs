using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    public static class PayUPageControls
    {
        public static readonly string cardPaymentButton = "//a[@href='#/payment/card']";
        public static readonly string cardNumberTextField = "//input[@id='card-number']";
        public static readonly string cvvTextField = "//input[@id='card-cvv']";
        public static readonly string nameTextField = "//input[@id='card-name']";
        public static readonly string emailTextField = "//input[@id='card-number']";
        public static readonly string submitButton = "//input[@name='submit']";
        public static readonly string expireToDate = "//input[@name='date']";


        public static (string cardNumber, string expireDate, string cvvNumber, string nameAndSurname, string email) sandboxCardDetails =
        (
            sandboxCardDetails.cardNumber = "4444333322221111",
            sandboxCardDetails.expireDate="01/21",
            sandboxCardDetails.cvvNumber="123",
            sandboxCardDetails.nameAndSurname="AAAAAAA BBBBBBBBB",
            sandboxCardDetails.email="aaa@wp.pl"
        );





    }
}
