using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PhotoSender_BBD_UI_Tests.DriverFactory;
using PhotoSender_BBD_UI_Tests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public sealed class LoginToApplicationNegativeSteps
    {

        private readonly MainWorkflow app;

        public LoginToApplicationNegativeSteps(MainWorkflow mainWorkflow)
        {
            app = mainWorkflow;
        }

        [When(@"I navigate to login page end enter incorrect UserName and Password")]
        public void WhenINavigateToLoginPageEndEnterIncorrectUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            app.
                CompleteLoginStage(data.UserName, data.Password);
        }

        [Then(@"Error message ""(.*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string p0)
        {
            Assert.AreEqual(p0, app.SwitchContextTo<LoginPage>().GetAlertText());
        }


    }
}
