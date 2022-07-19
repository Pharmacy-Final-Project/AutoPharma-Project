using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Models.Interfaces
{
    public interface ILocation
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocation(int Id);
        Task DeleteLocation(int Id);
        Task<Location> CreateLocation(Location location);
        Task<Location> UpdateLocation(int Id, Location location);
    }
}
