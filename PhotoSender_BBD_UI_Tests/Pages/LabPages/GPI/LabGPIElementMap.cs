using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.GPI
{
   public  class LabGPIElementMap : BasePageElementMap
   {
     
     


        public IWebElement NextButton
        {
            get { return Driver.FindElement(By.XPath(LabGPIControls.Xpath.nextButton)); }
        }


    }
}
