using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{
    public class LoginLabsElementMap : BasePageElementMap, ILoginLabsElementMap
    {
        public ILoginLabsPage LoginPage { get; set; }
     
        public IWebElement UserNameField
        {
            get
            {   
                return Driver.FindElement(By.XPath(LoginLabsPageControls.XPath.fieldUserName));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return Driver.FindElement((By.XPath(LoginLabsPageControls.XPath.fieldPassword)));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return Driver.FindElement(By.XPath(LoginLabsPageControls.XPath.SubmitButton));
            }
        }

        public IWebElement AlertMessage
        {

            get { return Driver.FindElement(By.XPath(LoginLabsPageControls.XPath.alertMessage)); }
        }

    }
}
