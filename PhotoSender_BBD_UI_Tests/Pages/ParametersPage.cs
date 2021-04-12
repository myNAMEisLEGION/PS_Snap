using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Factory;
using PhotoSender_BBD_UI_Tests.Pages.Locators;


namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IParametersPage
    {
        ParametersPage ClickQuantityIncreaseButton();
        CroppingPage ClickNextButton();
        ParametersPage SelectOptionFromFormatDropdown(int optionNumber);
        ParametersPage ClickApplyToAllButton();
        ParametersPage FixMinimalQuantityIfRequired();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class ParametersPage : BasePage, IParametersPage
    {
        private readonly IWebDriver _driver = DriverContext.Driver;

        private IWebElement GetFormatDropdownExpanderElement()
        {
            return GetElement(ParametersPageControls.FormatDropDownExpander);
        }

        private IWebElement GetNextButtonElement()
        {
            return GetElement(ParametersPageControls.nextButton);
        }

        private IWebElement GetQuantityIncreaseButton()
        {
            return GetElement(ParametersPageControls.increaseQuantityButton);
        }

        public ParametersPage ClickQuantityIncreaseButton()
        {
            _driver.FluentWaitForElementToBeClickable(ParametersPageControls.increaseQuantityButton);
            GetQuantityIncreaseButton().Click();

            return this;
        }
        public CroppingPage ClickNextButton()
        {
            _driver.FluentWaitForElementToBeClickable(ParametersPageControls.nextButton);
            GetNextButtonElement().Click();

            return SwitchContextTo<CroppingPage>();
        }

        private IWebElement GetQuantityValidationMessage()
        {
            return GetElement(ParametersPageControls.minimalQuantity);
        }
        private List<IWebElement> GetOptionsFormatDropDown()
        {
            GetFormatDropdownExpanderElement().Click();
            _driver.FluentWaitForElementToBeDisplayed(ParametersPageControls.FormatDropDownOption0);

            return GetElements(ParametersPageControls.FormatDropDownOptions).ToList();
        }

        public ParametersPage SelectOptionFromFormatDropdown(int optionNumber)
        {
            GetOptionsFormatDropDown()[optionNumber].Click();

            return this;
        }

        private IWebElement GetApplyToAllButtonElement()
        {
            return GetElement(ParametersPageControls.applyToAllButton);
        }

        public ParametersPage ClickApplyToAllButton()
        {
            _driver.FluentWaitForElementToBeClickable(ParametersPageControls.applyToAllButton);
            GetApplyToAllButtonElement().Click();

            return this;
        }

        private bool CheckIfMinimalQuantityIsReached()
        {
            try
            {
                _driver.FluentWaitForElementToBeDisplayed(ParametersPageControls.minimalQuantity,5);
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
