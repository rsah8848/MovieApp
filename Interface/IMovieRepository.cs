using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;

namespace IdentityMovie.Interface
{
    public interface IMovieRepository
    {
        bool AddMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int id);  
        Movie GetById(int id);
        List<Movie> GetAllMovies();
        List<SpMovie> SpGetAllMovies();
       
    }
}
