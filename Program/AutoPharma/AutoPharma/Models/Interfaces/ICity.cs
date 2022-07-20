using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Interfaces
{
    public interface ICity
    {
        Task<List<City>> GetAllCities();

        Task<City> GetCity(int Id);
        Task DeleteCity(int Id);
        Task<City> CreateCity(City city);
        Task<City> UpdateCity(int Id, City city);
    }
}
