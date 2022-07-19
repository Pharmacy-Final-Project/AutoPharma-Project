using AutoPharma.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPharma.Data
{
    public class AppDbContext : DbContext
    {
        //Tables in my database

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BranchMedicine> BranchMedicines { get; set; }
        public DbSet<Location> Locations { get; set; }



        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, City = "Amman", Address = "Amman Street", Phone = "1000" },
                new Branch { Id = 2, City = "Irbid", Address = "Irbid Street", Phone = "2000" }
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

        }
    }
}
