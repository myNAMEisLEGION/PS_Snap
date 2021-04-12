using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamitey;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Factory;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.ParametersPage
{
    public class ParametersPageElementMap : BasePageElementMap
    {
        public IWebElement FormatDropDownExpander
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.FormatDropDownExpander)); }
        }

        public IWebElement ApplyToAllButton
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.applyToAllButton)); }
        }

        public IWebElement CroppingDropDownExpander
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.croppingDropDownExpander)); }
        }

        public IWebElement PaperTypeDropDownExpander
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.paperTypeDropDownExpander)); }
        }

        public IWebElement QuantityField
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.quantityField)); }
        }

        public IWebElement IncreaseQuantityButton
        {
            get { return Driver.FindElement(By.XPath(ParametersPageControls.Xpath.increaseQuantityButton)); }
        }
        public IReadOnlyCollection<IWebElement> FormatDropDownOptions 
        {
            get
            {
              FormatDropDownExpander.Click();
              return Driver.FindElements(By.XPath(ParametersPageControls.Xpath.FormatDropDownOptions));
            }
        }


      

    }
}
