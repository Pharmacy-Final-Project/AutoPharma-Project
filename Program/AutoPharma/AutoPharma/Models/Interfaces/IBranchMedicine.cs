using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Interfaces
{
    public interface IBranchMedicine
    {
        Task<List<BranchMedicine>> GetAllBranchMedicine();
        Task<BranchMedicine> GetBranchMedicine(int Id);
        Task DeleteBranchMedicine(int Id);
        Task<BranchMedicine> CreateBranchMedicine(BranchMedicine branchMedicine);
        Task<BranchMedicine> UpdateBranchMedicine(int Id, BranchMedicine branchMedicine);

        Task AddMedicineToBranch(int branchId, int medicineId);
        Task RemoveMedicineFromBranch(int branchId, int medicineId);
    }
}
