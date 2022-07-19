using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class MedicineService : IMedicine
    {
        private readonly AppDbContext _context;

        public MedicineService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Medicine> CreateMedicine(Medicine medicine)
        {
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

        public async Task<Medicine> UpdateMedicine(int Id, Medicine medicine)
        {
            _context.Entry(medicine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicine;
        }
    }
}
