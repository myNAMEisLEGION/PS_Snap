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
    public interface ITitlePage
    {
        IWebElement GetLoginButtonElement();
        LoginPage ClickLoginToAccountButton();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class TitlePage : BasePage, ITitlePage
    {
        private IWebDriver driver;

        public IWebElement GetLoginButtonElement()
        {
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(TitlePageControls.loginToAccountButton);
            return GetElement(TitlePageControls.loginToAccountButton);
        }

        public LoginPage ClickLoginToAccountButton()
        {
            DriverContext.Driver.FluentWaitForElementToBeClickable(TitlePageControls.loginToAccountButton);
            GetLoginButtonElement().Click();
            return SwitchContextTo<LoginPage>();
        }

    }
}
