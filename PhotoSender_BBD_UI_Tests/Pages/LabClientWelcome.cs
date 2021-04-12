using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ILabClientWelcome
    {
        void ClickLoginLinkButton();
        LabClientLoginPage ClickBeginOrderButton();
        PhotoSelectionPage LoginToClientLab(string username =null, string password =null);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class LabClientWelcome : BasePage, ILabClientWelcome
    {
        private IWebDriver _driver = DriverContext.Driver;
        private IWebElement GetBeginOrderButton()
        {
            return GetElement(Controls.beginOrderButton);
        }

        private IWebElement GetLabClientWelcomePageHeader()
        {
            return GetElement(Controls.myLabPageHeader);
        }

        private IWebElement GetLoginLinkButton()
        {
            return GetElement(Controls.myLabPageLoginLink);
        }

        public void ClickLoginLinkButton()
        {
            _driver.FluentWaitForElementToBeClickable(Controls.myLabPageLoginLink);
            GetLoginLinkButton().Click();
        }

        public LabClientLoginPage ClickBeginOrderButton()
        {
            _driver.FluentWaitForElementToBeClickable(Controls.beginOrderButton);
            GetBeginOrderButton().Click();
            return SwitchContextTo<LabClientLoginPage>();
        }

        public PhotoSelectionPage LoginToClientLab(string username =null, string password =null)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                WaitForPageToBeLoaded();
                ClickBeginOrderButton()
                    .EnterCredentialsLabClientLoginPage()
                    .ClickLogInButton();
            }
            return SwitchContextTo<PhotoSelectionPage>();
        }

    }
}
