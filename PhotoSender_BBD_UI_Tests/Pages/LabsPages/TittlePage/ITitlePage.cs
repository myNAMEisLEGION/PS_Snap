using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Pages.LabPages.GPI;
using PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.TittlePage
{
    public interface ITitlePage
    {
        LoginLabsPage.LoginLabsPage ClickLoginToAccountButton();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
      
    }
}
