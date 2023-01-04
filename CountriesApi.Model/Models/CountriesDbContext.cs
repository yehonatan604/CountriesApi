using CountriesApi.Model.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CountriesApi.Model.Models
{
    public class CountriesDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set;}
        public DbSet<City> Cities { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                            "Server=DESKTOP-T74S10A;Database=CountriesDb;" +
                            "Trusted_Connection = True;" +
                            "TrustServerCertificate= True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
        }
    }
}
