using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.ViewModel
{
    public class ReportViewModel
    {
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BuyerName { get; set; }
    }
}
