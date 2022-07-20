using AutoPharma.Data;
using AutoPharma.Models.DTOs;
using AutoPharma.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BranchDTO> CreateBranch(Branch branch)
        {
            //_context.Entry(branch).State = EntityState.Added;
            //await _context.SaveChangesAsync();
            //return branch;

            BranchDTO NewBranch = new BranchDTO
            {
               Id=branch.Id,
               Address = branch.Address,
               Phone = branch.Phone,
                cityName = _context.Cities.FirstOrDefault(c => c.Id == branch.cityId).Name,
            };
            _context.Entry(branch).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return NewBranch;

        }

        public async Task DeleteBranch(int Id)
        {
            Branch branch = await _context.Branches.FindAsync(Id);

            _context.Entry(branch).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            //return await _context.Branches.ToListAsync();

            return await _context.Branches.Select(x =>  new Branch {
                cityName=_context.Cities.FirstOrDefault(c=>c.Id ==x.Id).Name,
                Address=x.Address,
                Phone=x.Phone

            
            }).ToListAsync();

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
