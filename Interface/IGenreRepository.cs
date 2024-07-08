using IdentityMovie.Models;

namespace IdentityMovie.Interface
{
    public interface IGenreRepository
    {
        bool AddGenre(Genre genre);
        bool UpdateGenre(Genre genre);
        bool DeleteGenre(int id);  
        Genre GetGenreById(int? id);
        List<Genre> GetAllGenres();
    }
}
