using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Shouldly;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class Controls
    {
        #region LoginPage

        public static readonly string fieldUserName = "//input[@type='text']";
        public static readonly string fieldPassword = "//input[@type='password']";
        public static readonly string subbmitButton = "//button[@type='submit']";
        public static readonly string btnLoginLink = "//a[@class='menu-link']";

        #endregion

        #region OverviewPage

        public static readonly string overviewHeader = "//h1/span";
        public static readonly string overviewFooter = "//div[@class='main-menu-login']";
        public static readonly string myLabLink = "//a[@target='_blank']";
        public static readonly string overviewPageUserMenuButton = "//*[@id='reactRoot']/div[2]/div[1]/div/div/div[2]/div[2]";
        public static readonly string overviewPageUserMenuSettings = "//a[@class='menu-link' and @href='/accounts/settings']";

        #endregion

        #region LabClientPage

        public static readonly string pageHeader = "//div[@class='header-wrapper']//span[@class='translate']";
        public static readonly string loginLinkButton = "//a[@class='menu-link'][@href='/lab/zxc12/accounts/login/']";

        #endregion

        #region LabCientWelcomePage

        public static readonly string myLabPageHeader = "//h1//span[@class='translate']";
        public static readonly string myLabPageFooter = "//div[@class='main-menu-login']";
        public static readonly string beginOrderButton = "//a[@class='link-button']";
        public static readonly string myLabPageLoginLink = "//div[@class='main-menu-element']/a";

        #endregion

        #region LabClientLoginPage

        public static readonly string labClientEmailField = "//input[@type='text']";
        public static readonly string labClientPasswordField = "//input[@type='password']";
        public static readonly string labClientLogInButton = "//button[@type='submit']";


        #endregion

        #region NewOrderPage

        public static readonly string newOrderPageNewOrderButton = "//a[@class='menu-link'][@href='/lab/zxc12/orders/new-order/upload-photos']";
        public static readonly string newOrderPageMyOrderButton = "//a[@class='menu-link'][@href='/lab/zxc12/orders']";
        public static readonly string newOrderPageNewOrderContent = "//span[@class='translate content-translate']";
        public static readonly string newOrderPageUserFooter = "//div[@class='main-menu-login']";
        #endregion

        #region LabAccountPage

        public static readonly string LabClientAccountPagePrefLang = "/html/body/div/div[3]/div[2]/div[2]/form/div/div/div/div[1]/div[1]/span";

        public static readonly string LabClientAccoutnSettingsURL = "https://photosender-qa-ui.azurewebsites.net/accounts/settings";

        public static readonly string LabAccountEditButton = "//*[@id='reactRoot']/div[2]/div[3]/div/div/div/div/div[1]/div[4]/button";

        public static readonly string LabAccountDropDownBreadcrumb = "/html/body/div/div[3]/div[2]/div[2]/form/div/div/div/div[2]/div[2]/div";

        public static readonly string LabAccountDropDownValuesPL = "//div[@id='react-select-2-option-1']";

        public static readonly string LabAccountDropDownSaveButton = "//*[@id='reactRoot']/div[3]/div[2]/div[2]/form/button/div[2]/span/span";

        #endregion

        #region OrderPage

        public static readonly string basicOrderElement = "";
        public static readonly string orderNumberOrderPage = "";
        public static readonly string createdDateOrderPage = "";

        #endregion

        #region UIParts

        public static readonly string pageBase = "//div[@id='reactRoot']";

        #endregion

    }



}
