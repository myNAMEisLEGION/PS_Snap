using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage
{
    public interface ILabClientLoginPageElementMap : IBasePageElementMap
    {
        IWebElement UserNameField { get; }
        IWebElement PasswordField { get; }
        IWebElement SubmitButton { get; }
        IWebDriver Driver { get; }
    }
}