using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context = Veritabanı ile projedeki class'ları birbirine bağlar.
    // Dbcontext, yüklediğimiz EfCore paketinden base olarak gelir.
    public class CarProjectContext : DbContext
    {
        // Hangi veritabanına bağlanacağını gösterdik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MP6HDBU; Database=CarProject; Trusted_Connection=true");
        }

        // Hangi class'ın hangi tabloya karşılık geldiğini gösterdik.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
