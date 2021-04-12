using System;
using Autofac;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Base
{
    public abstract class BasePage<TM> where TM : IBasePageElementMap
    {
        private IWebDriver _driver;
        private TM _element;
        private ILabsGPI _labsGpi;
        public IWebDriver Driver
        {
            get
            {
                if (_element != null)
                    return _driver;
                else
                {
                    return _driver = _scope.Resolve<IWebDriver>();
                }

            }
        }

        public TM Element
        {
            get
            {
                if (_element != null)
                    return _element;
                else
                {
                    return _element = _scope.Resolve<TM>();
                }
               
            }
        }

        public static IContainer container = ContainerConfig.Configure();
        public ILifetimeScope _scope = container.BeginLifetimeScope();
        
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
                    Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle,2);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            Driver.FluentWaitForElementToBeDisplayed(UIElements.mainLayout);
            Driver.FluentWaitForElementToBeDisplayed(Controls.pageBase);
        }

        private bool CheckIfPageIsLoading()
        {
            try
            {
                Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle,2);

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
                    Driver.FluentWaitForElementToBeDisplayed(UIElements.loadingCircle, 2);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            Driver.FluentWaitForElementToBeDisplayed(UIElements.mainLayout);
            Driver.FluentWaitForElementToBeDisplayed(Controls.pageBase);

            return SwitchContextTo<TPage>();
        }

    }
}
