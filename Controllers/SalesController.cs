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
            return View(null);
        }

        public IActionResult BillColumn(int id)
        {
            //Sales.Add(new Sales { Quantity = id,PurchaseDate=DateTime.Today });
            Sales sales= new Sales { Quantity = id, PurchaseDate = DateTime.Today };
            return PartialView(sales);
        }
        [HttpPost]
        public IActionResult Submit([FromBody]List<SalesReplyObject> model)
        {
            return View();
        }
    }
}