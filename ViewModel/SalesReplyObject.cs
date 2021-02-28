using DemoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.ViewModel
{
    public class SalesReplyObject
    {
        public string MedicineRefId { get; set; }
        public string Quantity { get; set; }
        public string Net { get; set; }
        public string PurchaseDate { get; set; }
        public string BuyerName { get; set; }
    }
}
