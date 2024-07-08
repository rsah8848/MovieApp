using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;

namespace IdentityMovie.Repository
{
    public class YearRepository : IYearRepository
    {
        private readonly ApplicationDbContext _context; 
        public YearRepository(ApplicationDbContext context) // It's a constructor of YearRepository class
        {
            _context = context; // initializing _context field
        }

        public bool AddYear(Year year)
        {
           _context.Years.Add(year);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteYear(Year year)
        {
            _context.Years.Remove(year);            
            _context.SaveChanges();
            return true;
        }

        public List<Year> GetAllYears()
        {
            var getyearlist =  _context.Years.ToList();
            return getyearlist;
        }

        public Year GetYearById(int? id)
        {
            var year = _context.Years.Find(id);
            return year;
        }

        public bool UpdateYear(Year year)
        {
            _context.Years.Update(year);
            _context.SaveChanges();
            return true;
        }
    }
}
