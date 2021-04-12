using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class OrdersPageControls
    {
        public static readonly string orderElement = "//div[@class='collapsible-list-row-header'][1]";
        public static readonly string orderNumber = "//div[@class='collapsible-list-row-header'][1]/div/div";
        public static readonly string orderCreatedDate = "";
        public static readonly string orderLastUpdated = "";
        public static readonly string orderTotalValue = "";
        public static readonly string orderStatus = "";
        public static readonly string orderPanelExpander = "";
        public static readonly string orderStatusDrobdownExpander = "";
        public static readonly string pageTitle = "//div[@class='page-header']//h1/span";
    }
}
