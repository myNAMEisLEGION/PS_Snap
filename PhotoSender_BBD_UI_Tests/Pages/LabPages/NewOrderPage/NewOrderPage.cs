using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.NewOrderPage
{
    public interface INewOrderPage
    {
        IWebElement GetNewOrderPageNewOrderButton();
        IWebElement GetNewOrderPageUserFooter();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class NewOrderPage : BasePage, INewOrderPage
    {
        public IWebElement GetNewOrderPageNewOrderButton()
        {
            return GetElement(Controls.newOrderPageNewOrderButton);
        }
        public IWebElement GetNewOrderPageUserFooter()
        {
            return GetElement(Controls.newOrderPageUserFooter);
        }

    }
}
