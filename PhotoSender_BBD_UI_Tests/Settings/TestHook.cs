using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Factory;
using TechTalk.SpecFlow;

namespace BBD_Automation_Framework.Pages.Settings
{
    [Binding]
    public sealed class TestHook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        
        [BeforeScenario]

        public void BeforeScenario()
        {
            DriverContext.GetInstance(BrowserType.Chrome);
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
            DriverContext.Driver.Dispose();
            DriverContext.Driver.Dispose();

        }
    }
}
