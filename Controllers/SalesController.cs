using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWebApp.ViewModel;

namespace DemoWebApp.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SalesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        
        public async Task<IActionResult> Details(string searchString)
        {
            var medicine = new Medicine();
            if (!String.IsNullOrEmpty(searchString))
            {
                medicine = await dbContext.Medicine.Where(s=>s.Name.Equals(searchString)).FirstOrDefaultAsync();
                if(medicine!=null)
                {
                    medicine.MedicineDetails = await dbContext.MedicineDetails.Where(t => t.MedicineRefId == medicine.Id).ToListAsync();
                }
                return PartialView(medicine);                  
            }
            return PartialView(null);
        }

        public IActionResult BillColumn(int id,int quantity,float rate)
        {
            Sales sales= new Sales {Quantity=quantity, Net=quantity*rate, MedicineDetailsRefId = id, PurchaseDate = DateTime.Today };
            return PartialView(sales);
        }
        [HttpPost]
        public IActionResult Submit([FromBody]List<SalesReplyObject> model)
        {
            var Sales=new  List<Sales>();
            foreach(SalesReplyObject item in  model)
            {
                Sales sales = new Sales
                {
                    Id=0,
                    MedicineDetailsRefId = int.Parse(item.MedicineRefId),
                    Quantity = int.Parse(item.Quantity),
                    Net = float.Parse(item.Net),
                    BuyerName=item.BuyerName,
                    PurchaseDate=DateTime.Parse(item.PurchaseDate)
                };
                Sales.Add(sales);
                var detail=dbContext.MedicineDetails.Find(int.Parse(item.MedicineRefId));
                detail.Quantity -= int.Parse(item.Quantity);
            }
            dbContext.Sales.AddRange(Sales);
            dbContext.SaveChanges();
            return Json(new { success = "Succesfully Submitted" });
        }
    }
}