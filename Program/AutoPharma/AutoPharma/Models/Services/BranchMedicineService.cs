using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class BranchMedicineService : IBranchMedicine
    {

        private readonly AppDbContext _context;

        public BranchMedicineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMedicineToBranch(int branchId, int medicineId)
        {
            BranchMedicine branchMedicine = new BranchMedicine()
            {
                BranchId = branchId,
                MedicineId = medicineId
            };
            _context.Entry(branchMedicine).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<BranchMedicine> CreateBranchMedicine(BranchMedicine branchMedicine)
        {
            _context.Entry(branchMedicine).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return branchMedicine;
        }

        public async Task DeleteBranchMedicine(int Id)
        {
            BranchMedicine branchMedicine = await _context.BranchMedicines.FindAsync(Id);

            _context.Entry(branchMedicine).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }



        public async Task<List<BranchMedicine>> GetAllBranchMedicine()
        {
            var AllBranchMedicines = await _context.BranchMedicines.Include(b => b.Branch).Include(b => b.Location).Include(b => b.Medicine).ToListAsync();
            return AllBranchMedicines;
        }

        public async Task<BranchMedicine> GetBranchMedicine(int Id)
        {
            var BranchMedicine = await _context.BranchMedicines.Include(b => b.Branch).Include(b => b.Location).Include(b => b.Medicine).FirstOrDefaultAsync();
            return BranchMedicine;
        }

        public async Task RemoveMedicineFromBranch(int branchId, int medicineId)
        {
            var removemedicine = await _context.BranchMedicines.FirstOrDefaultAsync(x => x.BranchId == branchId && x.MedicineId == medicineId);
            _context.Entry(removemedicine).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<BranchMedicine> UpdateBranchMedicine(int Id, BranchMedicine branchMedicine)
        {
            _context.Entry(branchMedicine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return branchMedicine;
        }
    }
}
