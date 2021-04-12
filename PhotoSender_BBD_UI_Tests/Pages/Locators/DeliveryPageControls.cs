using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class DeliveryPageControls
    {
        public static readonly string deliveryMethodContainer = "//div[@class='generic-tile']";
        public static readonly string deliveryMethodName = "//div [@class='title']";
        public static readonly string invoiceAddressSwitch = "//label[@class='switch']";
        public static readonly string deliveryAddress = "//div[@class='generic-tile address']";
        public static readonly string nextButton = "//div[@class='continue-button']";
        public static readonly string delliveryNameSelector =
            "//div[@class='generic-tile']//div[contains(string(),'Polish Post')]";
        //div[contains(text(),'DHL (za pobraniem)')]
    }
}
public enum Delivery
{
    PocztaPolska,
    PocztaPolskaZaPobraniem,
    OdbiórOsobisty,
    DHLZaPobraniem,
    UPS,
    FedEX,
    FedExZapobraniem,
}
