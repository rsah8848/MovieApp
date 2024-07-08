using IdentityMovie.Models;

namespace IdentityMovie.Interface
{
    public interface ICountryRepository
    {
        bool AddCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        Country GetCountryById(int? id);
        List<Country> GetAllCountries();

    }
}
