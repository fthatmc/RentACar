using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Entities;

namespace RentACar.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ATMACA\\SQLEXPRESS; database=RentACar; Integrated security = true; TrustServerCertificate=True;");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RentCar> RentACars { get; set; }

        //çoklu ilişki varsa alttaki satırlar yazılmalı
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentCar>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpCarLocation)
                .HasForeignKey(z => z.PickUpLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<RentCar>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffCarLocation)
                .HasForeignKey(z => z.DropOffLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
