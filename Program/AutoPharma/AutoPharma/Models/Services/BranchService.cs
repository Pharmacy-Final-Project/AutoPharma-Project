using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class BranchService : IBranch
    {
        private readonly AppDbContext _context;
        IConfiguration _configration;
        public BranchService(AppDbContext context, IConfiguration configuration)
        {
            _configration = configuration;
            _context = context;
        }

        public async Task<Branch> CreateBranch(Branch branch)
        {
            _context.Entry(branch).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task DeleteBranch(int Id)
        {
            Branch branch = await _context.Branches.FindAsync(Id);

            _context.Entry(branch).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetBranch(int Id)
        {
            var branch = await _context.Branches
                 .Include(n => n.BranchMedicines)
                 .ThenInclude(x => x.Medicine)
                 .FirstOrDefaultAsync(m => m.Id == Id);
            return branch;
        }

        public async Task<Branch> UpdateBranch(int Id, Branch branch)
        {
            _context.Entry(branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return branch;
        }
    }
}
