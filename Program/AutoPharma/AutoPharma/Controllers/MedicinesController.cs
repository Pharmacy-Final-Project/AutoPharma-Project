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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace AutoPharma.Controllers
{
    public class MedicinesController : Controller
    {

        private readonly IMedicine _medicine;
        private readonly IConfiguration _Configuration;


        public MedicinesController(IMedicine medicine, IConfiguration config)
        {
            _medicine = medicine;
            _Configuration = config;

        }

        // GET: Medicines
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var medicineList = await _medicine.GetAllMedicine();
            return View(medicineList);
        }


        // GET: Medicines/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create( Medicine medicine, IFormFile file)
        {
            //if (ModelState.IsValid)
            //{
            //    await _medicine.CreateMedicine(medicine);
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(medicine);


            BlobContainerClient container = new BlobContainerClient(_Configuration.GetConnectionString("AzureBlob"), "images");

            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            medicine.ImageUri = blob.Uri.ToString();
            if (ModelState.IsValid)
            {
                await _medicine.CreateMedicine(medicine);
                return RedirectToAction("Index");
            }
            stream.Close();
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id,Medicine medicine, IFormFile file)
        {

            BlobContainerClient container = new BlobContainerClient(_Configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };

            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }


            medicine.ImageUri = blob.Uri.ToString();
            await _medicine.UpdateMedicine(id, medicine);
            stream.Close();
            return RedirectToAction("Index");
        }

        // GET: Medicines/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
