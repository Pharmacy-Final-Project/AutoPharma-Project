using AutoPharma.Auth.Model;
using AutoPharma.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoPharma.Auth.Model.DTO;
using System;

namespace AutoPharma.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
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
                new Branch { Id = 2, CityId = 1, Address = "Abdon", Phone = "1200" },
                new Branch { Id = 3, CityId = 1, Address = "Marka", Phone = "1300" },
                new Branch { Id = 4, CityId = 1, Address = "Sweleh", Phone = "1400" },
                new Branch { Id = 5, CityId = 1, Address = "Al-sabea", Phone = "1500" },
                new Branch { Id = 6, CityId = 1, Address = "Al-thamin", Phone = "1600" },
                new Branch { Id = 7, CityId = 3, Address = "Irbid Street", Phone = "2100" },
                new Branch { Id = 8, CityId = 3, Address = "Albalad", Phone = "2200" },
                new Branch { Id = 9, CityId = 3, Address = "AL-ramtha", Phone = "2300" },
                new Branch { Id = 10, CityId = 3, Address = "Sal", Phone = "2400" },
                new Branch { Id = 11, CityId = 3, Address = "Irbid Street", Phone = "2500" }
                );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Panadol", Dose = "250", Information = "This medicine is used as a painkiller", MOHPrice = 3.5,ExpiredDate= new DateTime(2023,08,22)},
                new Medicine { Id = 2, Name = "Penicillin ", Dose = "500", Information = "This medicine is used as a antibiotic", MOHPrice = 17.65, ExpiredDate = new DateTime(2022, 08, 22) },
                new Medicine { Id = 3, Name = "FEXON", Dose = "180", Information = "This medicine is used as a Anti-allergic", MOHPrice = 4.95, ExpiredDate = new DateTime(2026, 06, 28) },
                new Medicine { Id = 4, Name = "DIAX SUSP", Dose = "220", Information = "This medicine is used as a 	Intestinal antiseptic", MOHPrice = 6.95, ExpiredDate = new DateTime(2024, 05, 26) },
                new Medicine { Id = 5, Name = "Zithrokan", Dose = "200", Information = "This medicine is used as a Antibiotics", MOHPrice = 1.2, ExpiredDate = new DateTime(2027, 02, 01) },
                new Medicine { Id = 6, Name = "Alvedon", Dose = "500", Information = "This medicine is used as a antipyretic", MOHPrice = 2.6, ExpiredDate = new DateTime(2024, 09, 12) },
                new Medicine { Id = 7, Name = "cyclease", Dose = "250", Information = "This medicine is used for cramps", MOHPrice = 4.7,  ExpiredDate = new DateTime(2025, 04, 19) },
                new Medicine { Id = 8, Name = "DAYQUIL", Dose = "400", Information = "This medicine is used for cold", MOHPrice = 1.1, ExpiredDate = new DateTime(2023, 03, 14) },
                new Medicine { Id = 9, Name = "Excedrin", Dose = "200", Information = "This medicine is used for headache", MOHPrice = 9.8, ExpiredDate = new DateTime(2027, 01, 11) }
               
                

                );

            modelBuilder.Entity<Location>().HasData(
                                //Location in Amman Branch
                                new Location { Id = 1, BranchId = 1, Cabinet = 'A', Shelf = 1 },
                new Location { Id = 2, BranchId = 1, Cabinet = 'A', Shelf = 2 },
                new Location { Id = 3, BranchId = 1, Cabinet = 'A', Shelf = 3 },
                new Location { Id = 4, BranchId = 1, Cabinet = 'A', Shelf = 4 },
                new Location { Id = 5, BranchId = 1, Cabinet = 'A', Shelf = 5 },
                new Location { Id = 6, BranchId = 1, Cabinet = 'B', Shelf = 1 },
                new Location { Id = 7, BranchId = 1, Cabinet = 'B', Shelf = 2 },
                new Location { Id = 8, BranchId = 1, Cabinet = 'B', Shelf = 3 },
                new Location { Id = 9, BranchId = 1, Cabinet = 'B', Shelf = 4 },
                new Location { Id = 10, BranchId = 1, Cabinet = 'B', Shelf = 5 },


                //Locations in Irbid Branch
                new Location { Id = 11, BranchId = 2, Cabinet = 'A', Shelf = 1 },
                new Location { Id = 12, BranchId = 2, Cabinet = 'A', Shelf = 2 },
                new Location { Id = 13, BranchId = 2, Cabinet = 'A', Shelf = 3 },
                new Location { Id = 14, BranchId = 2, Cabinet = 'A', Shelf = 4 },
                new Location { Id = 15, BranchId = 2, Cabinet = 'A', Shelf = 5 },
                new Location { Id = 16, BranchId = 2, Cabinet = 'B', Shelf = 1 },
                new Location { Id = 17, BranchId = 2, Cabinet = 'B', Shelf = 2 },
                new Location { Id = 18, BranchId = 2, Cabinet = 'B', Shelf = 3 },
                new Location { Id = 19, BranchId = 2, Cabinet = 'B', Shelf = 4 },
                new Location { Id = 20, BranchId = 2, Cabinet = 'B', Shelf = 5 }



                );

            modelBuilder.Entity<BranchMedicine>().HasData(
                //Panadol
                new BranchMedicine { Id = 1, BranchId = 1, LocationId = 1, MedicineId = 1, Count = 73, OurPrice = 3.75 },
                new BranchMedicine { Id = 2, BranchId = 2, LocationId = 5, MedicineId = 1, Count = 120, OurPrice = 3.75 },

                //FEXON
                new BranchMedicine { Id = 3, BranchId = 1, LocationId = 6, MedicineId = 3, Count = 99, OurPrice = 4.95 },
                new BranchMedicine { Id = 4, BranchId = 2, LocationId = 2, MedicineId = 3, Count = 55, OurPrice = 4.95 },
                new BranchMedicine { Id = 5, BranchId = 4, LocationId = 5, MedicineId = 3, Count = 55, OurPrice = 4.95 },
                new BranchMedicine { Id = 6, BranchId = 1, LocationId = 2, MedicineId = 3, Count = 85, OurPrice = 4.95 },

                //Excedrin
                new BranchMedicine { Id = 7, BranchId = 11, LocationId = 1, MedicineId = 9, Count = 53, OurPrice = 9.8 },
                new BranchMedicine { Id = 8, BranchId = 5, LocationId = 8, MedicineId = 9, Count = 73, OurPrice = 9.8 },
                new BranchMedicine { Id = 9, BranchId = 3, LocationId = 4, MedicineId = 9, Count = 76, OurPrice = 9.8 },
                new BranchMedicine { Id = 10, BranchId = 9, LocationId = 9, MedicineId = 9, Count = 13, OurPrice = 9.8 },

                //DAYQUIL
                new BranchMedicine { Id = 11, BranchId = 1, LocationId = 1, MedicineId = 8, Count = 73, OurPrice = 1.1 },
                new BranchMedicine { Id = 12, BranchId = 4, LocationId = 6, MedicineId = 8, Count = 55, OurPrice = 1.1 },
                new BranchMedicine { Id = 13, BranchId = 2, LocationId = 5, MedicineId = 8, Count = 66, OurPrice = 1.1 },
                new BranchMedicine { Id = 14, BranchId = 7, LocationId = 3, MedicineId = 8, Count = 44, OurPrice = 1.1 },

                //cyclease
                new BranchMedicine { Id = 15, BranchId = 1, LocationId = 1, MedicineId = 7, Count = 76, OurPrice = 4.7 },
                new BranchMedicine { Id = 16, BranchId = 6, LocationId = 2, MedicineId = 7, Count = 88, OurPrice = 4.7 },
                new BranchMedicine { Id = 17, BranchId = 3, LocationId = 3, MedicineId = 7, Count = 63, OurPrice = 4.7 },
                new BranchMedicine { Id = 18, BranchId = 4, LocationId = 4, MedicineId = 7, Count = 56, OurPrice = 4.7 },

                //Alvedon
                new BranchMedicine { Id = 19, BranchId = 1, LocationId = 1, MedicineId = 6, Count = 44, OurPrice = 2.6 },
                new BranchMedicine { Id = 20, BranchId = 2, LocationId = 6, MedicineId = 6, Count = 85, OurPrice = 2.6 },
                new BranchMedicine { Id = 21, BranchId = 7, LocationId = 8, MedicineId = 6, Count = 3, OurPrice = 2.6 },
                new BranchMedicine { Id = 22, BranchId = 8, LocationId = 2, MedicineId = 6, Count = 6, OurPrice = 2.6 },

                //Zithrokan
                new BranchMedicine { Id = 23, BranchId = 1, LocationId = 1, MedicineId = 5, Count = 99, OurPrice = 1.6 },
                new BranchMedicine { Id = 24, BranchId = 4, LocationId = 2, MedicineId = 5, Count = 53, OurPrice = 1.6 },
                new BranchMedicine { Id = 25, BranchId = 2, LocationId = 3, MedicineId = 5, Count = 44, OurPrice = 1.6 },
                new BranchMedicine { Id = 26, BranchId = 3, LocationId = 5, MedicineId = 5, Count = 66, OurPrice = 1.6 },
                new BranchMedicine { Id = 27, BranchId = 5, LocationId = 6, MedicineId = 5, Count = 62, OurPrice = 1.6 },
                new BranchMedicine { Id = 28, BranchId = 4, LocationId = 8, MedicineId = 5, Count = 74, OurPrice = 1.6 },

                //DIAX SUSP
                new BranchMedicine { Id = 29, BranchId = 1, LocationId = 1, MedicineId = 4, Count = 7, OurPrice = 6.95 },
                new BranchMedicine { Id = 30, BranchId = 11, LocationId = 2, MedicineId = 4, Count = 8, OurPrice = 6.95 },
                new BranchMedicine { Id = 31, BranchId = 2, LocationId = 3, MedicineId = 4, Count = 5, OurPrice = 6.95 },
                new BranchMedicine { Id = 32, BranchId = 4, LocationId = 2, MedicineId = 4, Count = 2, OurPrice = 6.95 },
                new BranchMedicine { Id = 33, BranchId = 2, LocationId = 3, MedicineId = 4, Count = 8, OurPrice = 6.95 },
                new BranchMedicine { Id = 34, BranchId = 3, LocationId = 7, MedicineId = 4, Count = 9, OurPrice = 6.95 },


                //Penicillin
                new BranchMedicine { Id = 35, BranchId = 1, LocationId = 1, MedicineId = 2, Count = 7, OurPrice = 17.65 },
                new BranchMedicine { Id = 36, BranchId = 2, LocationId = 2, MedicineId = 2, Count = 5, OurPrice = 17.65 },
                new BranchMedicine { Id = 37, BranchId = 4, LocationId = 3, MedicineId = 2, Count = 183, OurPrice = 17.65 },
                new BranchMedicine { Id = 38, BranchId = 11, LocationId = 4, MedicineId = 2, Count = 3, OurPrice = 17.65 },
                new BranchMedicine { Id = 39, BranchId = 1, LocationId = 5, MedicineId = 2, Count = 6, OurPrice = 17.65 },
                new BranchMedicine { Id = 40, BranchId = 5, LocationId = 6, MedicineId = 2, Count = 12, OurPrice = 17.65 },
                new BranchMedicine { Id = 41, BranchId = 3, LocationId = 7, MedicineId = 2, Count = 14, OurPrice = 17.65 },
                new BranchMedicine { Id = 42, BranchId = 6, LocationId = 8, MedicineId = 2, Count = 14, OurPrice = 17.65 },
                new BranchMedicine { Id = 43, BranchId = 8, LocationId = 9, MedicineId = 2, Count = 2, OurPrice = 17.65 },
                new BranchMedicine { Id = 44, BranchId = 9, LocationId = 10, MedicineId = 2, Count = 6, OurPrice = 17.65 }

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
