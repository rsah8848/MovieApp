using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace IdentityMovie.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }
        public bool AddMovie(Movie movie)
        {
            var yearlist = _context.Years.ToList();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMovie(Movie movie)
        {
            var yearlist = _context.Movies.ToList();
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public List<Movie> GetAllMovies()
        {
            var data = _context.Movies.Include(e => e.Year).Include(e => e.Genre).Include(e => e.Country).ToList();
            //List<Movie> movielist = _context.Movies
            //.Select(movie => new Movie
            //{
            //    Genre = _context.Genres.FirstOrDefault(g => g.Id == movie.GenreId),
            //    Country = _context.Countries.FirstOrDefault(c => c.Id == movie.CountryId),
            //    Year = _context.Years.FirstOrDefault(y => y.Id == movie.YearId)
            //})
            //.ToList();

            return data;
        }



        public Movie GetById(int id)
        {
            var film = _context.Movies.Find(id);
            return film;
        }

        //Trying something new for year,country and genre
        public List<Year> GetYears()
        {
            return _context.Years.ToList();
        }
        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();    
        }

        public Task<Movie> GetMovieById(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public List<SpMovie> SpGetAllMovies()
        {
            throw new NotImplementedException();
        }
    }
}
