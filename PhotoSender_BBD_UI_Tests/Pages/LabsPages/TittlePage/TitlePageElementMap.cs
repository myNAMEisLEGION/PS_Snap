using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.TittlePage
{
    public class TitlePageElementMap : BasePageElementMap, ITitlePageElementMap
    {
        public IWebElement LoginToAccountButton
        {
            get { return Driver.FindElement(By.XPath(TitlePageControls.Xpath.loginToAccountButton)); }
        }


    }
}
