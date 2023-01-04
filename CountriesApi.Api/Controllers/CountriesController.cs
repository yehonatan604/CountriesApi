using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountriesApi.Model.Models;
using AutoMapper;
using CountriesApi.Core.DTOs;
using Microsoft.AspNetCore.OData.Query;

namespace CountriesApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableQuery]
    public class CountriesController : ControllerBase
    {
        private readonly CountriesDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(CountriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountries()
        {
            var countries = _mapper.Map<List<CountryDTO>>(await _context.Countries.ToListAsync());
            return countries;
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
            var country = await GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetCountryDetailsDTO>(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<Country> GetDetails(int id)
        {
            return (await _context.Countries.Include(c => c.Cities)
                .SingleOrDefaultAsync(c => c.Id == id))!;
        }
        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
