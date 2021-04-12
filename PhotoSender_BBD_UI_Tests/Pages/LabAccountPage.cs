using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using Shouldly;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface ILabAccountPage
    {
        IWebElement GetLabAccountLanguage();
        string PreferredLabLanguage();
        LabAccountPage ClickLabAccountEditButton();
        LabAccountPage ClickLabAccountLanguageDropDOwnBreadCrumb();
        LabAccountPage ClickLabAccountLanguageDropDownValuePL();
        IWebElement GetLabAccountLanguageDropDownSaveButton();
        LabAccountPage ClickLabAccountLanguageDropDownSaveButton();
        LabAccountPage ClickLabAccountLanguageDropDownPL();
        LabAccountPage ClickLanguageDropDownSaveButton();
        LabAccountPage ClickLanguageDropDownCloseButton();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class LabAccountPage : BasePage, ILabAccountPage
    {
        private readonly IWebDriver _driver = DriverContext.Driver;
        public IWebElement GetLabAccountLanguage()
        {
            return GetElement(LabAccountPageControl.languagePreference);
        }

        public string PreferredLabLanguage()
        {
           return GetLabAccountLanguage().Text.ToLower();
        }

        private IWebElement GetLabAccountEditButton()
        {
            return GetElement(Controls.LabAccountEditButton);
        }

        public LabAccountPage ClickLabAccountEditButton()
        {
            GetLabAccountEditButton().Click();
            return this;
        }

        private IWebElement GetLabAccountLanguageDropDownBreadcrumb()
        {
            return GetElement(Controls.LabAccountDropDownBreadcrumb);
        }

        public LabAccountPage ClickLabAccountLanguageDropDOwnBreadCrumb()
        {
            GetLabAccountLanguageDropDownBreadcrumb().Click();
            return this;
        }

        private IWebElement GetLabAccountLanguageDropDownValuePL()
        {
            return GetElement(Controls.LabAccountDropDownValuesPL);
        }

        public LabAccountPage ClickLabAccountLanguageDropDownValuePL()
        {
            Thread.Sleep(TimeSpan.FromSeconds(4));
            GetLabAccountLanguageDropDownValuePL().Click();
            return this;
        }

        public IWebElement GetLabAccountLanguageDropDownSaveButton()
        {
            return GetElement(Controls.LabAccountDropDownSaveButton);
        }

        public LabAccountPage ClickLabAccountLanguageDropDownSaveButton()
        {
            GetLabAccountLanguageDropDownSaveButton();
            return this;
        }

        private IWebElement GetLabAccountLanguageDropDownPL()
        {
            return GetElement(LabAccountPageControl.languageDropDownOption0);
        }
        public LabAccountPage ClickLabAccountLanguageDropDownPL()
        {
            GetLabAccountLanguageDropDownPL().Click();
            return this;
        }

        private IWebElement GetLanguageDropDownSaveButtonElement()
        {
            return GetElement(LabAccountPageControl.languageDropDownSaveButton);
        }

        public LabAccountPage ClickLanguageDropDownSaveButton()
        {
            _driver.FluentWaitForElementToBeClickable(LabAccountPageControl.languageDropDownSaveButton);
            GetLanguageDropDownSaveButtonElement().Click();

            return this;
        }

        private IWebElement GetLanguageDropDownCloseButtonElement()
        {
            return GetElement(LabAccountPageControl.languageDropDownCloseButton);
        }

        public LabAccountPage ClickLanguageDropDownCloseButton()
        {
            _driver.FluentWaitForElementToBeClickable(LabAccountPageControl.languageDropDownCloseButton);
            GetLanguageDropDownCloseButtonElement().Click();

            return this;
        }



    }
}
