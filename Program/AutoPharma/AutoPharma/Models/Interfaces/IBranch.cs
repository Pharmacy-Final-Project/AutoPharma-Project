using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Interfaces
{
    public interface IBranch
    {
        Task<List<Branch>> GetAllBranches();
        Task<Branch> GetBranch(int Id);
        Task DeleteBranch(int Id);
        Task<Branch> CreateBranch(Branch branch);
        Task<Branch> UpdateBranch(int Id, Branch branch);



    }
}


