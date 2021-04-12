using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NUnit.Framework;
using PhotoSender_BBD_UI_Tests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public sealed class LoginNegativeSteps : BaseStep
    {
        private IMainWorkflow app;

        public LoginNegativeSteps()
        {
            app = InitializeApp().Resolve<IMainWorkflow>();
        }

        [When(@"I navigate to login page end enter incorrect UserName and Password")]
        public void WhenINavigateToLoginPageEndEnterIncorrectUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            app.
                CompleteLoginStage(data.UserName, data.Password);
        }

        [Then(@"I am not logged in and error message ""(.*)"" is displayed")]
        public void ThenIAmNotLoggedInAndErrorMessageIsDisplayed(string p0)
        {
            Assert.AreEqual(p0, app.SwitchContextTo<LoginPage>().GetAlertText());
        }


    }
}
