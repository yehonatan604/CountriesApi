using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountriesApi.Model.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
    }
}
