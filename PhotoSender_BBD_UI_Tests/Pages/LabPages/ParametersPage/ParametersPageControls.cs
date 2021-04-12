using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.ParametersPage
{
    public static class ParametersPageControls
    {
        public static class Xpath
        {
            #region ChooseFormatDropdown

            public static readonly string FormatDropDownExpander =
                "//*[@id='reactRoot']/div[2]/div[3]/div[1]/div/div/div/div/div[2]/div[1]/div/div/form/div[1]/div/div/div[2]/div[2]/div";

            public static readonly string FormatDropDownOption0 = "//div[@id='react-select-2-option-0']";
            public static readonly string FormatDropDownOption1 = "//div[@id='react-select-2-option-1']";
            public static readonly string FormatDropDownOption2 = "//div[@id='react-select-2-option-2']";
            public static readonly string FormatDropDownOption3 = "//div[@id='react-select-2-option-3']";
            public static readonly string FormatDropDownOption4 = "//div[@id='react-select-2-option-4']";
            public static readonly string FormatDropDownOption5 = "//div[@id='react-select-2-option-5']";
            public static readonly string FormatDropDownOption6 = "//div[@id='react-select-2-option-6']";

            public static readonly string FormatDropDownOptions = "//div[contains(@id,'react-select-2-option-')]";

            #endregion

            public static readonly string applyToAllButton =
                "//button[@class='button select-items block primary order-row auto icon-or-animation-displayed']";

            #region SelectCropingDropDown

            public static readonly string croppingDropDownExpander =
                "/html/body/div/div[2]/div[3]/div/div/div/div/div/div[2]/div[1]/div/div/form/div[2]/div/div/div[2]/div/div";

            public static readonly string croppingDropDownOptions = "//div[contains(@id,'react-select-2-option-')]";

            #endregion

            #region PaperTypeDropDown

            public static readonly string paperTypeDropDownExpander =
                "/html/body/div/div[2]/div[3]/div/div/div/div/div/div[2]/div[1]/div/div/form/div[3]/div/div/div[2]/div[2]/div";

            public static readonly string paperTypeDropDownOptions = "//div[contains(@id,'react-select-2-option-')]";

            #endregion

            public static readonly string quantityField = "//div[@class='number-input non-empty']//input[@type='number']";

            public static readonly string applyToSelectedButton =
                "//button[@class='button submit-button block primary order-row auto']";

            public static readonly string minimalQuantity =
                "/html/body/div/div[2]/div[3]/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div/div[6]/div/div/div[4]/form/div[4]/div[1]/div/span/span";

            public static readonly string nextButton = "//button[@class='button workflow-button block primary order-row-reverse full icon-or-animation-displayed']";

            public static readonly string increaseQuantityButton =
                "/html/body/div/div[2]/div[3]/div/div/div/div/div/div[2]/div[1]/div/div/form/div[4]/div/button[2]";

        }

        public static class Id
        {





        }


    }
}
