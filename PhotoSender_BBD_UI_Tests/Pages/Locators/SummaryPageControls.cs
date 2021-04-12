using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    public static class SummaryPageControls
    {
        public static readonly string nextButton = "//div[@class='continue-button']";
        public static readonly string photoContainer = "//div[@class='photo-container']";
        public static readonly string discountTextField = "//div[@class='section-content discount-form']//input";
        public static readonly string orderTotalValue = "//div[@class='price-after-discount']";
        public static readonly string discountSaveButton = "//button[@type='submit']";

        public static readonly string alertError = "//div[@class='alert error']/span";
        public static readonly string alertSuccess = "//span[@class='alert-text']";
        public static readonly string progressBar = "//div[@class='progress-bar-background']";
        public static readonly string progressBarThemed = "//div[@class='progress-bar-themed']";
        public static (string discountName, double discountValue) discount50 = ("50PROC", 50);

    }
}
