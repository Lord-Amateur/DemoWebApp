using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Models
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ReportController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index(string searchString)
        {

            return View();
        }
    }
}