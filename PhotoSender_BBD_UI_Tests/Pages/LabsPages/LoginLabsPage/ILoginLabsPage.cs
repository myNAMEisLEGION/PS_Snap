using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{
    public interface ILoginLabsPage
    {              
        LoginLabsPage LogInToApplication(string userName = null, string password = null);
        string GetAlertText(); 
        OverviewPage ClickSubmitButton();
        LoginLabsPage EnterUserName(string userName);
        LoginLabsPage EnterPassword(string password);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }      
}
