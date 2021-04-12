using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class TopMenuLabUserControls
    {
        public static readonly string newOrderLink = "//div[@class='main-menu-element'][1]/a";
        public static readonly string myOrdersLink = "//div[@class='main-menu-element'][2]/a";
        public static readonly string loggedUserIndicator = "";
        public static readonly string backToWelcomePageLink = "";
        public static readonly string userMenuDropDown = "//*[@id='reactRoot']/div[2]/div[1]/div/div/div[2]/div[2]";
        public static readonly string userMenuDropDownSettings = "//a[@class='menu-link' and @href='/accounts/settings']";
    }
}
