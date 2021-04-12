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
    public interface ITopMenuUserLab
    {
        UserLabOrderPage ClickOrderButton();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class TopMenuUserLab : BasePage, ITopMenuUserLab
    {
        private IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetOrderButtonElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(TopMenuLabUserControls.myOrdersLink);
            return GetElement(TopMenuLabUserControls.myOrdersLink);
        }

        public UserLabOrderPage ClickOrderButton()
        {
            _driver.FluentWaitForElementToBeClickable(TopMenuLabUserControls.myOrdersLink);
            GetOrderButtonElement().Click();

            return SwitchContextTo<UserLabOrderPage>();
        }

    }
}

