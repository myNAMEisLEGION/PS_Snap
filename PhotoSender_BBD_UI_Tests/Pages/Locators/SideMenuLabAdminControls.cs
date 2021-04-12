using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class SideMenuLabAdminControls
    {

        public static readonly string overviewLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/overview']";

        public static readonly string ordersLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/orders']";

        public static readonly string reportsLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/reports']";

        public static readonly string clientsLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/clients']";

        public static readonly string fliesLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/files']";

        public static readonly string contactSupportLink = "//div[@class='side-tab-navigation hide']/a[@href='/labs/my-lab/contact-support']";

    }
}
