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
    public interface ILabAdminTopMenu
    {
        OverviewPage SelectMainMenuDropDownAccountSettingsOptions();
        LabAccountPage NavigateToAccountSettingPage();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class LabAdminTopMenu : BasePage, ILabAdminTopMenu
    {
        private readonly IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetMainMenuButtonElement()
        {
            return GetElement(LabAdminTopMenuControls.mainMenuDropdown);
        }

        private LabAdminTopMenu ClickMainMenuButton()
        {
            
            _driver.FluentWaitForElementToBeClickable(LabAdminTopMenuControls.mainMenuDropdown);
            GetMainMenuButtonElement().Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            GetMainMenuButtonElement().Click();

            return this;
        }

        private IWebElement GetMainMenuDropDownAccountSettingsElement()
        {
            return GetElement(LabAdminTopMenuControls.mainMenuDropdownAcountSettings);
        }

        public OverviewPage SelectMainMenuDropDownAccountSettingsOptions()
        {
            _driver.FluentWaitForElementToBeClickable(LabAdminTopMenuControls.mainMenuDropdownAcountSettings);
            GetMainMenuDropDownAccountSettingsElement().Click();

            return SwitchContextTo<OverviewPage>();
        }

        public LabAccountPage NavigateToAccountSettingPage()
        {
            _driver.Navigate().GoToUrl(LabAdminTopMenuControls.AccountSetttingsPageLink);

            return SwitchContextTo<LabAccountPage>();
        }
        

    }
}
