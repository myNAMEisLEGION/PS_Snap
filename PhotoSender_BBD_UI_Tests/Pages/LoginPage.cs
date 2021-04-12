using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dynamitey;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ILoginPage
    {
        LoginPage LogInToApplication(string userName = null, string password = null);
        string GetAlertText();
        OverviewPage ClickSubmitButton ();
        LoginPage EnterUserName(string userName);
        LoginPage EnterPassword(string password);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
        
    }

    public class LoginPage : BasePage, ILoginPage
    {
        private IOverviewPage _overviewPage;
        private ITitlePage _titlePage;
        private IDriverContext _driverContext;

        public LoginPage(IDriverContext driverContext, IOverviewPage overviewPage, ITitlePage titlePage)
        {
            _driverContext = driverContext;
            _overviewPage = overviewPage;
            _titlePage = titlePage;
        }

        public LoginPage LogInToApplication(string userName = null, string password = null)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                WaitForPageToBeLoaded(); 
                _titlePage
                    .ClickLoginToAccountButton()
                    .EnterUserName(userName)
                    .EnterPassword(password);
            }

            return this;
        }

        private IWebElement GetSubmitButton()
        {
            return GetElement(LoginPageControls.logInButton);
        }

        private IWebElement GetLoginField()
        {
            return GetElement(Controls.fieldUserName);
        }

        private IWebElement GetPasswordField()
        {
            return GetElement(Controls.fieldPassword);
        }

        private IWebElement GetAlertElement()
        {
            return GetElement(LoginPageControls.alertMessage);
        }

        public string GetAlertText()
        {
            return  GetAlertElement().Text;
        }
        public OverviewPage ClickSubmitButton ()
        {
            _driverContext.Driver.FluentWaitForElementToBeClickable(LoginPageControls.logInButton);
            GetSubmitButton().Click();
           return SwitchContextTo<OverviewPage>();
        }

        public LoginPage EnterUserName(string userName)
        {
            GetLoginField().SendKeys(userName);
            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            GetPasswordField().SendKeys(password);
            return this;
        }

    }
}
