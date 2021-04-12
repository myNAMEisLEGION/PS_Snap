using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PhotoSender_BBD_UI_Tests.Base
{
    public class BaseGPI
    {
        public IWebDriver Driver { get; private set; }
        public BaseGPI(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
