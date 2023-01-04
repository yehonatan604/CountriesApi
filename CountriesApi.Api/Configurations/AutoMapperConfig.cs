using AutoMapper;
using CountriesApi.Core.DTOs;
using CountriesApi.Model.Models;

namespace CountriesApi.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDTO>().ReverseMap();
            
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, GetCityDTO>().ReverseMap();


        }
    }
}
