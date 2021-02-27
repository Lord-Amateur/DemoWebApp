using DemoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.ViewModel
{
    public class SalesViewModel
    {
        public Medicine Medicine { get; set; }
        public List<Sales> Sales { get; set; }
        public int Total { get; set; }
    }
}
