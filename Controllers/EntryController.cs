using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    public class EntryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EntryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Medicine> medicines = dbContext.Medicine;
            return View(medicines);
        }

        //Get- Create
        public IActionResult Create()
        {
            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medicine medicine)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(medicine);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        //Get- Edit
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var medicine = dbContext.Medicine.Find(id);
            if(medicine==null )
            {
                return NotFound();
            }
            return View(medicine);
        }

        //Post- Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                dbContext.Update(medicine);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        //Get- Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicine = dbContext.Medicine.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return View(medicine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var medicine = dbContext.Medicine.Find(id);
            if (medicine!=null)
            {
                dbContext.Remove(medicine);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        //Get- Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicine = dbContext.Medicine.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return View(medicine);
        }
    }
}