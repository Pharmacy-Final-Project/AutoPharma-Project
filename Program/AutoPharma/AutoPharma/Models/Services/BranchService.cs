using AutoPharma.Auth.Model;
using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        IConfiguration _configration;

        public BranchService(AppDbContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configration = configuration;
            _context = context;
            _userManager = userManager;
        }

        public async Task<Branch> CreateBranch(Branch branch)
        {
            _context.Entry(branch).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return branch;

            //BranchDTO NewBranch = new BranchDTO
            //{
            //    Id = branch.Id,
            //    Address = branch.Address,
            //    Phone = branch.Phone,
            //    cityName = _context.Cities.FirstOrDefault(c => c.Id == branch.cityId).Name,
            //};
            //_context.Entry(branch).State = EntityState.Added;
            //await _context.SaveChangesAsync();
            //return NewBranch;

        }

        public async Task DeleteBranch(int Id)
        {
            Branch branch = await _context.Branches.FindAsync(Id);

            _context.Entry(branch).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            return await _context.Branches
                //.Include(x => x.City)
                .Include(y => y.BranchMedicines)
                .ToListAsync();

            //return await _context.Branches.Select(x =>
            //new Branch {
            //cityName=_context.Cities.FirstOrDefault(c=>c.Id ==x.Id).Name,
            //Address=x.Address,
            //Phone=x.Phone

            //}).ToListAsync();

        }
          // return  await _userManager.Users.ToListAsync();
        public async Task<Branch> GetBranch(int? Id)
        {
            var branch = await _context.Branches
                 //.Include(y => y.City)
                 .Include(n => n.BranchMedicines)
                 .ThenInclude(x => x.Medicine)
                 .FirstOrDefaultAsync(m => m.Id == Id);


            branch.Pharmacists = await _userManager.Users
                .Where(u => u.BranchId == Id)
                .ToListAsync();
            
            return branch;
        }

        public async Task<Branch> UpdateBranch(int Id, Branch branch)
        {
            _context.Entry(branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return branch;
        }
      
        //public async Task<List<BranchMedicine>> Search(string text, int branchId)
        //{

        //    var result = await _context.BranchMedicines.Include(m => m.Medicine).Where(b => b.BranchId == branchId && (b.Medicine.Name.Contains(text) || b.Medicine.Information.Contains(text))).ToListAsync();
        //    return result;
        //}
    }
}
