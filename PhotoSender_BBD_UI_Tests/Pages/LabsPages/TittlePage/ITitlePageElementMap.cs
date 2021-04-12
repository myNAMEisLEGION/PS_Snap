using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.TittlePage
{
    public interface ITitlePageElementMap : IBasePageElementMap
    {
        IWebElement LoginToAccountButton { get; }
        IWebDriver Driver { get; }
       
    }
}