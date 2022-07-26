﻿using AutoPharma.Data;
using AutoPharma.Models;
using AutoPharma.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Controllers
{
    public class BranchMedicinesController : Controller
    {
        private readonly IBranch _branch;
        private readonly IBranchMedicine _branchMedicine;
        private readonly AppDbContext _context;

        public BranchMedicinesController(IBranchMedicine branchMedicine, AppDbContext context, IBranch branch)
        {
            _branchMedicine = branchMedicine;
            _context = context;
            _branch = branch;

        }

        // GET: BranchMedicines
        public async Task<IActionResult> Index()
        {

            var AllBranchMedicine = await _branchMedicine.GetAllBranchMedicine();
            return View(AllBranchMedicine);
        }



        // GET: BranchMedicines/Details/5
        [Authorize(Roles = "Admin, Pharmacist")]

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        public IActionResult ChooseCity()
        {
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            ViewBag.Id = new SelectList(_context.Cities, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult ChooseCity(City city)
        {
            //it returns an empty city with correct id i select from list
            //now here, i return a list of branches, where Branch.CityId == city.id
            //the problem now is that im returning to the same view
            //so I want to redirect to a new view that does the same thing but for branch now!

            ViewBag.secondId = new SelectList(_context.Branches.Where(x => x.CityId == city.Id), "Id", "Address");



            return View("ChooseBranch");
        }


        public IActionResult ChooseBranch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChooseBranch(Branch branch)
        {
            ViewBag.secondId = _context.Branches.Where(x => x.Id == branch.Id).FirstOrDefault().Id;
            var branchMedicines = await _context.BranchMedicines.Where(x => x.BranchId == branch.Id)
                .Include(y => y.Medicine)
                .Include(z => z.Branch)
                .ToListAsync();

            return View("Index", branchMedicines);
        }
        //public async Task<IActionResult> Filter(int id)
        //{

        //    return View();

        //}
        [HttpPost]

        public async Task<IActionResult> Filter(string searchString, Branch branch)
        {
            if (branch.Id == 0)
            {
                var branchMedicines = await _context.BranchMedicines
                  .Include(y => y.Medicine)
                  //.Include(z => z.Branch)
                  .ToListAsync();
                if (!string.IsNullOrEmpty(searchString))
                {
                    var filteredResultNew = _context.BranchMedicines.Where(x => x.Medicine.Information.Contains(searchString) || x.Medicine.Name.Contains(searchString));


                    return View("Index", filteredResultNew);
                }
                return View("Index", branchMedicines);
            }
            else
            {
                ViewBag.secondId = _context.Branches.Where(x => x.Id == branch.Id).FirstOrDefault().Id;

                var branchMedicines = await _context.BranchMedicines.Where(x => x.BranchId == branch.Id)
                   .Include(y => y.Medicine)
                   //.Include(z => z.Branch)
                   .ToListAsync();

                if (!string.IsNullOrEmpty(searchString))
                {
                    var filteredResultNew = branchMedicines.Where(x => x.BranchId == branch.Id && (x.Medicine.Information.Contains(searchString) || x.Medicine.Name.Contains(searchString)));


                    return View("Index", filteredResultNew);
                }


                return View("Index", branchMedicines);
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>


        // GET: BranchMedicines/Create
        [Authorize(Roles = "Admin, Pharmacist")]

        public IActionResult Create()
        {

            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Name");
            return View();
        }

        // POST: BranchMedicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("Id,MedicineId,BranchId,LocationId,Count,OurPrice")] BranchMedicine branchMedicine)
        {
            if (ModelState.IsValid)
            {
                await _branchMedicine.CreateBranchMedicine(branchMedicine);
                return RedirectToAction(nameof(Index));
            }

            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address", branchMedicine.BranchId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", branchMedicine.LocationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Name", branchMedicine.MedicineId);
            return View(branchMedicine);
        }

        // GET: BranchMedicines/Edit/5
        [Authorize(Roles = "Admin, Pharmacist")]

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
        [Authorize(Roles = "Admin, Pharmacist")]

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
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

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
