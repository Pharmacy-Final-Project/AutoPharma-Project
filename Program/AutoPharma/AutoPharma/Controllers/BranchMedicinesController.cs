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

namespace AutoPharma.Controllers
{
    public class BranchMedicinesController : Controller
    {
        private readonly IBranchMedicine _branchMedicine;
        private readonly AppDbContext _context;

        public BranchMedicinesController(IBranchMedicine branchMedicine, AppDbContext context)
        {
            _branchMedicine = branchMedicine;
            _context = context;

        }

        // GET: BranchMedicines
        public async Task<IActionResult> Index()
        {
            var AllBranchMedicine = await _branchMedicine.GetAllBranchMedicine();
            return View(AllBranchMedicine);
        }

        // GET: BranchMedicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchMedicine = await _branchMedicine.GetBranchMedicine((int)id);
            if (branchMedicine == null)
            {
                return NotFound();
            }

            return View(branchMedicine);
        }

        // GET: BranchMedicines/Create
        public IActionResult Create()
        {
            var x = _branchMedicine.GetAllBranchMedicine();
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id");
            return View();
        }

        // POST: BranchMedicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicineId,BranchId,LocationId,Count,OurPrice")] BranchMedicine branchMedicine)
        {
            if (ModelState.IsValid)
            {
                await _branchMedicine.CreateBranchMedicine(branchMedicine);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", branchMedicine.BranchId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", branchMedicine.LocationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", branchMedicine.MedicineId);
            return View(branchMedicine);
        }

        // GET: BranchMedicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchMedicine = await _branchMedicine.GetBranchMedicine((int)id);
            if (branchMedicine == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", branchMedicine.BranchId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", branchMedicine.LocationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", branchMedicine.MedicineId);
            return View(branchMedicine);
        }

        // POST: BranchMedicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicineId,BranchId,LocationId,Count,OurPrice")] BranchMedicine branchMedicine)
        {
            if (id != branchMedicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _branchMedicine.UpdateBranchMedicine(id, branchMedicine);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchMedicineExists(branchMedicine.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", branchMedicine.BranchId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", branchMedicine.LocationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", branchMedicine.MedicineId);
            return View(branchMedicine);
        }

        // GET: BranchMedicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchMedicine = await _branchMedicine.GetBranchMedicine((int)id);
            if (branchMedicine == null)
            {
                return NotFound();
            }

            return View(branchMedicine);
        }

        // POST: BranchMedicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _branchMedicine.DeleteBranchMedicine(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BranchMedicineExists(int id)
        {
            var branchMedicine = _branchMedicine.GetBranchMedicine((int)id);
            if (branchMedicine == null)
            {
                return false;
            }
            else return true;
        }
    }
}
