using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using DemoWebApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Models
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ReportController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index(string searchString,DateTime? fromDate,DateTime? toDate)
        {
            //Medicine medicine = new Medicine();
            if (!String.IsNullOrEmpty(searchString))
            {
                var medicine = dbContext.Medicine.Where(s => s.Name.Equals(searchString)).FirstOrDefault();
                if (medicine != null)
                {
                    var data = from details in dbContext.MedicineDetails
                               join sales in dbContext.Sales
                               on details.Id equals sales.MedicineDetailsRefId
                               where details.MedicineRefId == medicine.Id
                               select new ReportViewModel
                               {
                                   BatchNo = details.BatchNo,
                                   Quantity = sales.Quantity,
                                   PurchaseDate = sales.PurchaseDate,
                                   BuyerName = sales.BuyerName
                               };
                    if (fromDate.HasValue)
                        data = data.Where(d => d.PurchaseDate >= fromDate);
                    if(toDate.HasValue)
                    data = data.Where(d => d.PurchaseDate <= toDate);
                                return View(data.ToList());
                } 
            }
            return View(null);
        }
    }
}