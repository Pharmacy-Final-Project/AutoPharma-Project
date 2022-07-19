using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPharma.Data;
using AutoPharma.Models;

namespace AutoPharma.Controllers
{
    public class BranchMedicinesController : Controller
    {
        private readonly AppDbContext _context;

        public BranchMedicinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BranchMedicines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BranchMedicines.Include(b => b.Branch).Include(b => b.Location).Include(b => b.Medicine);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BranchMedicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchMedicine = await _context.BranchMedicines
                .Include(b => b.Branch)
                .Include(b => b.Location)
                .Include(b => b.Medicine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchMedicine == null)
            {
                return NotFound();
            }

            return View(branchMedicine);
        }

        // GET: BranchMedicines/Create
        public IActionResult Create()
        {
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
                _context.Add(branchMedicine);
                await _context.SaveChangesAsync();
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

            var branchMedicine = await _context.BranchMedicines.FindAsync(id);
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
                    _context.Update(branchMedicine);
                    await _context.SaveChangesAsync();
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

            var branchMedicine = await _context.BranchMedicines
                .Include(b => b.Branch)
                .Include(b => b.Location)
                .Include(b => b.Medicine)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var branchMedicine = await _context.BranchMedicines.FindAsync(id);
            _context.BranchMedicines.Remove(branchMedicine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchMedicineExists(int id)
        {
            return _context.BranchMedicines.Any(e => e.Id == id);
        }
    }
}
