using System;
using System.Linq;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.ParametersPage
{

    public class ParametersPage : BasePage<ParametersPageElementMap>, IParametersPage
    {
        public ParametersPage(IWebDriver driver, ILabGPI labGpi, ILabsGPI labsGpi):base(driver, labGpi, labsGpi)
        {
           
        }

        public IWebElement this[string value] => SelectDropDownValue(value);

        private IWebElement SelectDropDownValue(string value)
        {    
            return Element.FormatDropDownOptions.First(x => x.GetAttribute("text").Equals(value));
        }

        
       

        private bool CheckIfMinimalQuantityIsReached()
        {
            try
            {
                Driver.FluentWaitForElementToBeDisplayed(Locators.ParametersPageControls.minimalQuantity,5);
            }
            catch (Exception e)
            {
                return true;
            }

            return false;
        }

        private void IncreasePhotosQuantity()
        {
            while (CheckIfMinimalQuantityIsReached() == false)
            {
                ClickQuantityIncreaseButton();
                ClickApplyToAllButton();
            }
           
        }

        public ParametersPage FixMinimalQuantityIfRequired()
        {
            IncreasePhotosQuantity();

            return this;
        }

        



    }
}
