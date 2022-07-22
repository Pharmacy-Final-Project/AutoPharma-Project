using AutoPharma.Auth.Model;
using AutoPharma.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoPharma.Auth.Model.DTO;

namespace AutoPharma.Data
{
    public class AppDbContext : IdentityDbContext<PharmacistUser>
    {
        //Tables in my database

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BranchMedicine> BranchMedicines { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<RegisterDTO> Pharmacists { get; set; }
      


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            


            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, CityId = 1, Address = "Amman Street", Phone = "1000" },
                new Branch { Id = 2, CityId = 3, Address = "Irbid Street", Phone = "2000" }
                );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Panadol", Dose = "250", Information = "This medicine is used as a painkiller", MOHPrice = 3.5 },
                new Medicine { Id = 2, Name = "Penicillin ", Dose = "500", Information = "This medicine is used as a antibiotic", MOHPrice = 17.65 }

                );

            modelBuilder.Entity<Location>().HasData(
                //Location in Amman Branch
                new Location { Id = 1, BranchId = 1, Cabinet = 'A', Shelf = 1 },
                new Location { Id = 2, BranchId = 1, Cabinet = 'A', Shelf = 2 },
                new Location { Id = 3, BranchId = 1, Cabinet = 'A', Shelf = 3 },


                //Locations in Irbid Branch
                new Location { Id = 4, BranchId = 2, Cabinet = 'A', Shelf = 1 },
                new Location { Id = 5, BranchId = 2, Cabinet = 'A', Shelf = 2 },
                new Location { Id = 6, BranchId = 2, Cabinet = 'A', Shelf = 3 }



                );

            modelBuilder.Entity<BranchMedicine>().HasData(
                //Panadol
                new BranchMedicine { Id = 1, BranchId = 1, LocationId = 1, MedicineId = 1, Count = 73, OurPrice = 3.75 },
                new BranchMedicine { Id = 2, BranchId = 2, LocationId = 5, MedicineId = 1, Count = 120, OurPrice = 3.75 },

                //Antibiotic
                new BranchMedicine { Id = 3, BranchId = 1, LocationId = 3, MedicineId = 2, Count = 22, OurPrice = 18.45 },
                new BranchMedicine { Id = 4, BranchId = 2, LocationId = 6, MedicineId = 2, Count = 17, OurPrice = 18.45 }

                );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Amman"},
                new City { Id = 2, Name = "Zarqa"},
                new City { Id = 3, Name = "Irbid"},
                new City { Id = 4, Name = "Aqaba"},
                new City { Id = 5, Name = "Maadaba" },
                new City { Id = 6, Name = "Al-Balqaa"},
                new City { Id = 7, Name = "Mafraq" },
                new City { Id = 8, Name = "Jerash" },
                new City { Id = 9, Name = "Ma'an" },
                new City { Id = 10, Name = "Al-Tafila" },
                new City { Id = 11, Name = "Al-Karak" },
                new City { Id = 12, Name = "Ajloun"}
                
                );

        }

        
    }
}
