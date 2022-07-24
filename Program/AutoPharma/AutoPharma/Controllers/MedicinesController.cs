using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPharma.Data;
using AutoPharma.Models;
using AutoPharma.Models.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AutoPharma.Controllers
{
    public class MedicinesController : Controller
    {

        private readonly IMedicine _medicine;

        public MedicinesController(IMedicine medicine)
        {
            _medicine = medicine;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            var medicineList = await _medicine.GetAllMedicine();
            return View(medicineList);
        }
        

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicine.GetMedicine((int)id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Dose,MOHPrice,Information,ImageUri")] Medicine medicine, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                await _medicine.CreateMedicine(medicine,file);
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicine.GetMedicine((int)id);
            if (medicine == null)
            {
                return NotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Medicine medicine, IFormFile file)
        {
            if (id != medicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _medicine.UpdateMedicine(id, medicine,file);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicine.GetMedicine((int)id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicine.DeleteMedicine(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            var Medicine = _medicine.GetMedicine((int)id);
            if (Medicine == null)
            {
                return false;
            }
            else return true;
        }
        public async Task<IActionResult> GetExpiredAfterMonth()
        {
            var medicineList = await _medicine.GetExpiredAfterMonth();
            return View(medicineList);
        }
        public async Task<IActionResult> ExpiredAfterTwomonth()
        {
            var medicineList = await _medicine.GetExpiredAfterTwoMonth();
            return View(medicineList);
        }
        public async Task<IActionResult> SortByExpirationDate()
        {
            var medicineList = await _medicine.SortByExpirationDate();
            return View(medicineList);
        }
    }
}
