using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Pages.LabPages.GPI;
using PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage;


namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.TittlePage
{
    public class TitlePage : BasePage<ITitlePageElementMap>, ITitlePage
    {

        public LoginLabsPage.LoginLabsPage ClickLoginToAccountButton()
        {
            
            LabsLoginPage.LogInToApplication();
            return SwitchContextTo<LoginLabsPage.LoginLabsPage>();
          
        }

    }

}
