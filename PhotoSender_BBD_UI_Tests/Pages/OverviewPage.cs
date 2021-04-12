using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.Page;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IOverviewPage
    {
        IWebElement GetMyLabLink();
        LabClientWelcome ClickMyLabLink();
        IWebElement GetOverviewUserMenu();
        IWebElement GetUserMenuSettingsOption();
        LabAccountPage ClickOnUserMenuSettingOption();
        LabAccountPage NavigateToAccountSettings();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class OverviewPage : BasePage, IOverviewPage
    {

        public IWebElement GetMyLabLink()
        {
            DriverContext.Driver.FluentWaitForElementToBeClickable(OverviewPageControls.myLabLink);
            return GetElement(Controls.myLabLink);
        }
        public LabClientWelcome ClickMyLabLink()
        {
            GetMyLabLink().Click();
            return SwitchContextTo<LabClientWelcome>();
        }
        public IWebElement GetOverviewUserMenu()
        {
            return GetElement(Controls.overviewPageUserMenuButton);
        }
        public IWebElement GetUserMenuSettingsOption()
        {
            return GetElement(Controls.overviewPageUserMenuSettings);
        }
        
        public LabAccountPage ClickOnUserMenuSettingOption()
        {
            var page = SwitchContextTo<OverviewPage>();
            var element = page.GetOverviewUserMenu();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            page.GetUserMenuSettingsOption();
            return SwitchContextTo<LabAccountPage>();
        }

        public LabAccountPage NavigateToAccountSettings()
        {
            var menu = new LabAdminTopMenu();
            menu.NavigateToAccountSettingPage();

            return SwitchContextTo<LabAccountPage>();
        }

    }
}
