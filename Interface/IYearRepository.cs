using IdentityMovie.Models;

namespace IdentityMovie.Interface
{
    public interface IYearRepository
    {
        bool AddYear(Year year);
        bool UpdateYear(Year year);
        bool DeleteYear(Year year);
        Year GetYearById(int? id);
        List<Year> GetAllYears();

    }
}
