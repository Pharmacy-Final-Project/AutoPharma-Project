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
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using AutoPharma.Auth.Model;

namespace AutoPharma.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IBranch _branch;
        private readonly ICity _city;
        private readonly AppDbContext _context;
        

        public BranchesController(IBranch branch, ICity city, AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _branch = branch;
            _city = city;
            _context = context;
        }
      
        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var branchList = await _branch.GetAllBranches();
            return View(branchList);
        }

        //GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branch.GetBranch(id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
      

        // GET: Branches/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");


            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,Address,Phone")] Branch branch)
        {
            
            if (ModelState.IsValid)
            {
                await _branch.CreateBranch(branch);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", branch.CityId);


            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branch.GetBranch((int)id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Address,Phone")] Branch branch)
        {
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _branch.UpdateBranch(id, branch);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Id))
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
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branch.GetBranch((int)id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _branch.DeleteBranch(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            var branch = _branch.GetBranch((int)id);
            if (branch == null)
            {
                return false;
            }
            else return true;


        }
        //public async Task<IActionResult> Search(string text, int BranchId)
        //{
        //    var result = _branch.Search(text, BranchId);
        //    return View("Details", result);
        //}
    }
}
