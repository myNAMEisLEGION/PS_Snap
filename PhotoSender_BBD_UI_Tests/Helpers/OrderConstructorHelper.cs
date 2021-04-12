using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dynamitey.DynamicObjects;

namespace PhotoSender_BBD_UI_Tests.Helpers
{ 
    public class OrderConstructorHelper
    {
        public string OrderNumber { get; set; }
        public  string CreatedDate { get; set; }
        public  string LastUpdate { get; set; }
        public string TotalValue { get; set; }

       public  OrderConstructorHelper(string ordernumber)
        {
            OrderNumber = ordernumber;
        }


       
        
    }
}
