using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.GPI
{
    public class LabGPI : BasePage<ILabGPIElementMap>, ILabGpi 
    {
        public LabGPI()
        {
           
        }

        public TPage ClickNextButton<TPage>() 
        {
            Element.
            return SwitchContextTo<TPage>();
        }

    }
}
