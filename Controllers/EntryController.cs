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
            if (ModelState.IsValid)
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


        //Post-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var medicine = dbContext.Medicine.Find(id);
            if (medicine != null)
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
            medicine.MedicineDetails = dbContext.MedicineDetails.Where(t => t.MedicineRefId == id).ToList();
            return View(medicine);
        }

        //Get- CreateDetails
        public IActionResult CreateDetail(int? id)
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
            MedicineDetails medicineDetails = new MedicineDetails { MedicineRefId=(int)id};
            return View(medicineDetails);
        }

        //Post- CreateDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetail(MedicineDetails medicineDetails)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(medicineDetails);
                dbContext.SaveChanges();
                return RedirectToAction("Details", new { id = medicineDetails.MedicineRefId });
            }
            return View(medicineDetails);
        }

        //Get- EditDetails
        public IActionResult EditDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicineDetials = dbContext.MedicineDetails.Find(id);
            if (medicineDetials == null)
            {
                return NotFound();
            }
            return View(medicineDetials);
        }

        //Post- EditDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetails(MedicineDetails medicineDetails)
        {
            if (ModelState.IsValid)
            {
                dbContext.Update(medicineDetails);
                dbContext.SaveChanges();
                return RedirectToAction("Details",new { id =medicineDetails.MedicineRefId });
            }
            return View(medicineDetails);
        }

        //Get- DeleteDetails
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicineDetails = dbContext.MedicineDetails.Find(id);
            if (medicineDetails == null)
            {
                return NotFound();
            }
            dbContext.Remove(medicineDetails);
            dbContext.SaveChanges();

            return RedirectToAction("Details", new { id = medicineDetails.MedicineRefId });
        }

    }
}