using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using PhotoSender_BBD_UI_Tests.Factory;

namespace PhotoSender_BBD_UI_Tests.Base
{
    public abstract class BasePageElementMap : IBasePageElementMap
    {
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                    return _driver;
                else
                    return _driver = _scope.Reslove<IWebDriver>;

            }

        }
    }
}
