using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;

namespace IdentityMovie.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository (ApplicationDbContext context) 
        { 
            _context = context;
        }

        public bool AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return true;
        }

        public List<Country> GetAllCountries()
        {
            var countryList = _context.Countries.ToList();
            return countryList;
        }

        public Country GetCountryById(int? id)
        {
            var country = _context.Countries.Find(id);
            return country;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
            return true;
        }
    }
}
