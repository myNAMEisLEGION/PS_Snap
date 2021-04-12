using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class LabAdminTopMenuControls
    {
        public static readonly string mainMenuDropdown = "/html/body/div/div[2]/div[1]/div/div/div[2]/div[2]/div[1]/div";

        public static readonly string AccountSetttingsPageLink =
            "https://photosender-qa-ui.azurewebsites.net/accounts/settings";
        public static readonly string mainMenuDropdownAcountSettings = "//a[@href = '/accounts/settings']";

        public static readonly string mainMenuDropdownLogOut =
            "/html/body/div/div[2]/div[1]/div/div/div[2]/div[2]/div[1]/div/div[3]/div/div[2]";

        public static readonly string mainLogo = "//a[@class='main-logo']";

    }
}
