using System.ComponentModel.DataAnnotations;

namespace CountriesApi.Core.DTOs
{
    public class CityDTO
    {
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
