using AutoMapper;
using CountriesApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesApi.Model.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    FullName = "Jamaica",
                    ShortName= "JM",
                }, 
                new Country
                {
                    Id = 2,
                    FullName = "Israel",
                    ShortName = "IL",
                },
                new Country
                {
                    Id = 3,
                    FullName = "France",
                    ShortName = "FR",
                }
            );
        }
    }
}
