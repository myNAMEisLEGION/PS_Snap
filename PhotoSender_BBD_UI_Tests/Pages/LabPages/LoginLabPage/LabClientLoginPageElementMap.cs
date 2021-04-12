using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage
{
    public class LabClientLoginPageElementMap : BasePageElementMap, ILabClientLoginPageElementMap
    {
        public IWebElement UserNameField
        {
            get => Driver.FindElement(By.XPath(LabClientLoginPageControls.Xpath.userNameField));
        }
        public IWebElement PasswordField
        {
            get => Driver.FindElement(By.XPath(LabClientLoginPageControls.Xpath.passwordField));
        }

        public IWebElement SubmitButton
        {
            get => Driver.FindElement(By.XPath(LabClientLoginPageControls.Xpath.submitButton));
        }
    }
}
