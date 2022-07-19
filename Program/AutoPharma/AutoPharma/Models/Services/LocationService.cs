using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class LocationService : ILocation
    {

        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task DeleteLocation(int Id)
        {
            Location location = await _context.Locations.FindAsync(Id);

            _context.Entry(location).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocation(int Id)
        {
            var location = await _context.Locations
                 .FirstOrDefaultAsync(m => m.Id == Id);
            return location;
        }

        public async Task<Location> UpdateLocation(int Id, Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
    }
}

