using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ILabClientLoginPage
    {
        PhotoSelectionPage ClickLogInButton();
        LabClientLoginPage EnterCredentialsLabClientLoginPage(string username=null, string password=null);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class LabClientLoginPage : BasePage, ILabClientLoginPage
    {
        private IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetEmailField()
        {
            return GetElement(LoginPageControls.fieldUserName);
        }

        private IWebElement GetPasswordField()
        {
            return GetElement(LoginPageControls.fieldPassword);
        }

        private IWebElement GetLogInButton()
        {
            return GetElement(LoginPageControls.logInButton);
        }

        public PhotoSelectionPage ClickLogInButton()
        {
            GetLogInButton().Click();
            return SwitchContextTo<PhotoSelectionPage>();
        }


        public LabClientLoginPage EnterCredentialsLabClientLoginPage(string username=null, string password=null)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                WaitForPageToBeLoaded();
                GetEmailField().SendKeys(username);
                GetPasswordField().SendKeys(password);
            }

            return this;
        }
    }
}