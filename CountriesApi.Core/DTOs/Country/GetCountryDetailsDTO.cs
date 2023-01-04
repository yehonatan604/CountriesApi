namespace CountriesApi.Core.DTOs
{ 
    public class GetCountryDetailsDTO : GetCountryDTO
    {
        public List<CityDTO> Cities { get; set; }
    }
}
