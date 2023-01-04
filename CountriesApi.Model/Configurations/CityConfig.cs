

using CountriesApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesApi.Model.Configurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    Id = 1,
                    Name= "Tel-Aviv",
                    CountryId= 2,
                },
                new City
                {
                    Id = 2,
                    Name = "Kingston",
                    CountryId = 1,
                },
                new City
                {
                    Id = 3,
                    Name = "Haifa",
                    CountryId = 2,
                },
                new City
                {
                    Id = 4,
                    Name = "Paris",
                    CountryId = 3,
                },
                new City
                {
                    Id = 5,
                    Name = "Ramat-Gan",
                    CountryId = 2,
                }
            );
        }
    }
}
