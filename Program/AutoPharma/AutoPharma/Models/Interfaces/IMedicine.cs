using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Interfaces
{
    public interface IMedicine
    {

        Task<List<Medicine>> GetAllMedicine();
        Task<Medicine> GetMedicine(int Id);
        Task DeleteMedicine(int Id);
        Task<Medicine> CreateMedicine(Medicine medicine);
        //, IFormFile file
        Task<Medicine> UpdateMedicine(int Id, Medicine medicine, IFormFile file);
        Task<List<Medicine>> SortByExpirationDate();
        Task<List<Medicine>> GetExpiredAfterTwoMonth();
        Task<List<Medicine>> GetExpiredAfterMonth();

    }
}
