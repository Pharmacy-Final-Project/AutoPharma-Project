using AutoPharma.Data;
using AutoPharma.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Models.Services
{
    public class CityService : ICity
    {
        private readonly AppDbContext _context;
        IConfiguration _configration;
        public CityService(AppDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configration = configuration;

        }

        public async Task<City> CreateCity(City city)
        {
            _context.Entry(city).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task DeleteCity(int Id)
        {
            City city = await _context.Cities.FindAsync(Id);

            _context.Entry(city).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCity(int Id)
        {
            var city = await _context.Cities
               
              .FirstOrDefaultAsync(m => m.Id == Id);
            return city;
        }

       

        public async Task<City> UpdateCity(int Id, City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return city;
        }
    }
}
