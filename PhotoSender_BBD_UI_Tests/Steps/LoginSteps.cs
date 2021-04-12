using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using BBD_Automation_Framework.Pages.Settings;
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
    public sealed class LoginSteps: BaseStep
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private IMainWorkflow app;
       

        public LoginSteps()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();
            app = scope.Resolve<IMainWorkflow>();
        }

        [Given(@"Application is opened")]
        public void GivenApplicationIsOpened()
        {
            DriverContext.Driver.Navigate().GoToUrl("https://photosender-qa-ui.azurewebsites.net/");
            //DriverContext.Driver.Manage().Window.Maximize();
        }

        [When(@"I navigate to login page end enter UserName and Password")]
        public void WhenINavigateToLoginPageEndEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            
            app.
                CompleteLoginStage(data.UserName, data.Password);
        }

        [Then(@"I am successfully loged in")]
        public void ThenIAmSuccessfullyLogedIn()
        {
            
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(OverviewPageControls.overviewHeader);
            Assert.AreEqual("podsumowanie", DriverContext.Driver.FindElement(By.XPath(OverviewPageControls.overviewHeader)).Text.ToLower());
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(OverviewPageControls.logedUserIndicator);
            Assert.AreEqual("zxc12", DriverContext.Driver.FindElement(By.XPath(OverviewPageControls.logedUserIndicator)).Text.ToLower());
            app.SetLabLanguageTo();
        }

    }
}
