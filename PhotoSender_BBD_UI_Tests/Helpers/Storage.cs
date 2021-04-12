using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoSender_BBD_UI_Tests.Helpers
{
    public static class Storage
    {
        public static int OrderNumber { get; set; }

        public static int PhotoCountAdded { get; set; }

        public static int PhotoCountSummary { get; set; }

        public static string PaymentMethod { get; set; }

        public static double TotalValue { get; set; }

        public static double DeliveryPrice { get; set; }

        public static double PriceAfterDiscount { get; set;}
        
            
        
    }
}
