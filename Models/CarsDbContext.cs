using Microsoft.EntityFrameworkCore;

namespace CarsApi.Models
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(            
                new Car { Id = 5, make = "Mazda", model = "mazda-2", color = "Bronze", year = 2015, price = 150000 },                
                new Car { Id = 6, make = "Toyota", model = "Campry", color = "Yellow", year = 2002, price = 50000 },                
                new Car { Id = 7, make = "BMW", model = "X6", color = "Red", year = 2019, price = 500000 },                
                new Car { Id = 8, make = "Mercedes", model = "A200", color = "White", year = 2020, price = 900000 },
                new Car { Id = 9, make = "Audi", model = "A3", color = "Grey", year = 2019, price = 500000 },                
                new Car { Id = 10, make = "Audi", model = "S3", color = "Blue", year = 2023, price = 1500000 }
                );
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { Id = 1, UserName = "Admin", Password = "adm1n"},
                new UserAccount { Id = 2, UserName = "User2", Password = "passw01d"}
                );
        }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
