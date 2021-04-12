using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{
    public interface ILoginLabsElementMap : IBasePageElementMap
    {
        ILoginLabsPage LoginPage { get; set; }
        IWebElement UserNameField { get; }
        IWebElement PasswordField { get; }
        IWebElement SubmitButton { get; }
        IWebDriver Driver { get; }
        IWebElement AlertMessage { get; }
    }
}