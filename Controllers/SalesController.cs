using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SalesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var medicine = new Medicine();
            if (!String.IsNullOrEmpty(searchString))
            {
                medicine = await dbContext.Medicine.Where(s=>s.Name.Equals(searchString)).FirstOrDefaultAsync();
                if(medicine!=null)
                {
                    medicine.MedicineDetails = await dbContext.MedicineDetails.Where(t => t.MedicineRefId == medicine.Id).ToListAsync();
                }
                return View(medicine);
                                    
            }

            return View(null);
        }
    }
}