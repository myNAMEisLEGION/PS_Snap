using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Google.Protobuf;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public abstract class BasePage : Base
    {
        private static readonly IContainer _container = ContainerConfig.Configure();
        private readonly ILifetimeScope _scope = _container.BeginLifetimeScope();
        public IWebDriver WebDriver { get; set; }
        
        public TPage SwitchContextTo<TPage>() 
        { 
            try
            {
                _scope.IsRegistered<TPage>();
                return _scope.Resolve<TPage>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal TPage SwitchTabTo<TPage>(int tabnumber = 1)
        {
            SwitchToTab(tabnumber);
            return SwitchContextTo<TPage>();
        }

        public void WaitForPageToBeLoaded()
        {
            while (CheckIfPageIsLoading() == true)
            {
                try
                {
                    DriverContext.Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle,2);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            DriverContext.Driver.FluentWaitForElementToBeDisplayed(UIElements.mainLayout);
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(Controls.pageBase);
        }

        private bool CheckIfPageIsLoading()
        {
            try
            {
                DriverContext.Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle,2);

                return true;
            }
            catch (Exception e)
            { 
                return false;
            }
        }

        public TPage WaitForPageToBeLoaded<TPage>() 
        {
            while (CheckIfPageIsLoading() == true)
            {
                try
                {
                    DriverContext.Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle, 2);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            DriverContext.Driver.FluentWaitForElementToBeDisplayed(UIElements.mainLayout);
            DriverContext.Driver.FluentWaitForElementToBeDisplayed(Controls.pageBase);

            return SwitchContextTo<TPage>();
        }

    }
}
