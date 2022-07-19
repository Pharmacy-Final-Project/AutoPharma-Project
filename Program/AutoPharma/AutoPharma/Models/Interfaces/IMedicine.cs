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
        Task<Medicine> UpdateMedicine(int Id, Medicine medicine);
    }
}
