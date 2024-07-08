using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
//using IdentityMovie.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace IdentityMovie.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class MovieController : Controller
    {
        //Initializing Required Repositories
        public readonly IMovieRepository _movieRepository;
        public readonly IYearRepository _yearRepository;
        public readonly ICountryRepository _countryRepository;
        public readonly IGenreRepository _genreRepository;
        public readonly ICommentRepository _commentRepository;
        public readonly IWebHostEnvironment _webHostEnvironment; //used for serving static file in specific directories 

        public MovieController(IMovieRepository movieRepository, ICountryRepository countryRepository, IYearRepository yearRepository, IGenreRepository genreRepository, ICommentRepository commentRepository, IWebHostEnvironment webHostEnvironment )
        {
            _movieRepository = movieRepository;
            _yearRepository = yearRepository;
            _countryRepository = countryRepository;
            _genreRepository = genreRepository;
            _commentRepository = commentRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var getlist = _movieRepository.SpGetAllMovies();
            return View(getlist);
        }


        [HttpGet]
        public IActionResult Create()
        {
           
            var yearlist = new SelectList (_yearRepository.GetAllYears(), "Id", "Years");
            ViewData["YearId"] = yearlist;

            var genrelist = new SelectList (_genreRepository.GetAllGenres(), "Id", "GenreName");
            ViewData["GenreId"] = genrelist;

            var countrylist = new SelectList (_countryRepository.GetAllCountries(), "Id", "Name");
            ViewData["CountryId"] = countrylist;

            return View();
           
        }

        [HttpPost]
        public IActionResult Create(CreateMovieVM movie)
        {
            var path = _webHostEnvironment.WebRootPath;
            var filePath = "Movie/CoverPhoto/" + movie.MovieId + movie.ImagePath.FileName;
            var fullPath = Path.Combine(path, filePath);
            UploadFile(movie.ImagePath, fullPath);
            var newmovie = new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                GenreId = movie.GenreId,
                YearId = movie.YearId,
                CountryId = movie.CountryId,
                Photo = filePath
            };
            _movieRepository.AddMovie(newmovie);
            TempData["SuccessMessages"] = "Movie created sucessfully!";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var yearlist = new SelectList(_yearRepository.GetAllYears(), "Id", "Years");
            ViewData["YearId"] = yearlist;

            var genrelist = new SelectList(_genreRepository.GetAllGenres(), "Id", "GenreName");
            ViewData["GenreId"] = genrelist;

            var countrylist = new SelectList(_countryRepository.GetAllCountries(), "Id", "Name");
            ViewData["CountryId"] = countrylist;

            var movie = _movieRepository.GetById(id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            /*var image = Request.Form.Files.FirstOrDefault();
            var fileName = Guid.NewGuid().ToString();
            var path = $@"Movies\";
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var uploads = Path.Combine(wwwRootPath, path);
            var extension = Path.GetExtension(image.FileName);
            var x = Path.Combine(uploads, fileName + extension);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                image.CopyTo(fileStreams);
            }
            movie.Photo = $"\\Movies\\{fileName}" + extension;*/
            var edit = _movieRepository.UpdateMovie(movie);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var remove = _movieRepository.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        
       {
            Movie movie = _movieRepository.GetById(id);
            List<CommentVM> comments = _commentRepository.GetComments(id);
            Year yearList = _yearRepository.GetYearById(movie.YearId);
            Genre GenreList = _genreRepository.GetGenreById(movie.GenreId);
            Country CountryList = _countryRepository.GetCountryById(movie.CountryId);
            MovieDetailsVM movieDetails = new MovieDetailsVM 
            { 
                Movie = movie,
                Comments = comments,
                Year = yearList,
                Genre = GenreList,
                Country = CountryList
            };
            
        
            return View(movieDetails);
        }

        [HttpPost]
        public IActionResult Details(Movie movie)
        {
            var details = _movieRepository.GetById(movie.MovieId);
            return RedirectToAction("Index");
        }


        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
