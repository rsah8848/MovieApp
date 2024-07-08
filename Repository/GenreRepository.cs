using Humanizer.Localisation;
using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using System.Security.AccessControl;

namespace IdentityMovie.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return true;

        }
        public bool DeleteGenre(int id)
        {
            var genre = _context.Genres.Find(id);
            if(genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
                return true;
            }
           return false;
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int? id)
        {
            var genre = _context.Genres.Find(id);
            return genre;
        }

        public bool UpdateGenre(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return true;
        }
    }
}
