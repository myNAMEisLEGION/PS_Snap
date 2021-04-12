using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages;
using PhotoSender_BBD_UI_Tests.Pages.Locators;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PhotoSender_BBD_UI_Tests.Steps
{
    [Binding]
    public sealed class LogInToClientLab
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly MainWorkflow app;

        public LogInToClientLab(MainWorkflow mainworkflow)
        {
            app = mainworkflow;
        }
        [Then(@"Link to Client Lab is displayed")]
        public void ThenLinkToClientLabIsDisplayed()
        {
            
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(OverviewPageControls.myLabLink);
            app.SwitchContextTo<OverviewPage>().WaitForPageToBeLoaded();
            Assert.AreEqual("https://photosender-qa-ui.azurewebsites.net/lab/zxc12", DriverContext.Driver.FindElement(By.XPath(OverviewPageControls.myLabLink)).Text.ToLower());

        }

        [When(@"I navigate to Client Lab Page and enter UserName and Password")]
        public void WhenINavigateToClientLabPageAndEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            app
                .SwitchContextTo<OverviewPage>()
                .ClickMyLabLink()
                .LoginToClientLab(data.UserName, data.Password);
        }

        [Then(@"User is logged in to client lab welcome page is displayed")]
        public void ThenUserIsLoggedInToClientLabWelcomePageIsDisplayed()
        {
            Assert.AreEqual("zxc12", DriverContext.Driver.FindElement(By.XPath(PhotosSelectionControls.userIndicator)).Text.ToLower());
        }


    }
}
