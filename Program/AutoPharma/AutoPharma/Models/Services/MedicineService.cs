using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class MedicineService : IMedicine
    {
        private readonly AppDbContext _context;
        IConfiguration _configration;
        public MedicineService(AppDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configration = configuration;
        }
        public async Task<Medicine> CreateMedicine(Medicine medicine)
        {
            //, IFormFile file
            //medicine.ImageUri = GetFile(file).Result;
            _context.Entry(medicine).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return medicine;

          
        }

        public async Task DeleteMedicine(int Id)
        {
            Medicine medicine = await _context.Medicines.FindAsync(Id);

            _context.Entry(medicine).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Medicine>> GetAllMedicine()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetMedicine(int Id)
        {
            var medicine = await _context.Medicines
                 .FirstOrDefaultAsync(m => m.Id == Id);
            return medicine;
        }

        public async Task<Medicine> UpdateMedicine(int Id, Medicine medicine, IFormFile file)
        {
            if (file != null)
            {
              //  medicine.ImageUri = GetFile(file).Result;

            }
            _context.Entry(medicine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicine;
        }
        public async Task<Uri> GetFile(IFormFile file)
        {
            if (file == null)
            {
                Uri defaultimg = new Uri("https://autopharmastorage.blob.core.windows.net/images/default.jpg");
                return defaultimg;
            }
            BlobContainerClient container = new BlobContainerClient(_configration.GetConnectionString("AzureBlob"), "images");
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
            return blob.Uri;

        }
        public async Task<List<Medicine>> GetExpiredAfterMonth()
        {

            var medicine = await _context.Medicines.Where(p => (DateTime.Today - p.ExpiredDate).Days <= 30).ToListAsync();
            return medicine;
        }
        public async Task<List<Medicine>> GetExpiredAfterTwoMonth()
        {

            var medicine = await _context.Medicines.Where(p => (DateTime.Today - p.ExpiredDate).Days <= 60).ToListAsync();
            return medicine;
        }
        public async Task<List<Medicine>> SortByExpirationDate()
        {

            var medicines = await _context.Medicines.OrderBy(p => p.ExpiredDate).ToListAsync();
            return medicines;
        }

    }
}
