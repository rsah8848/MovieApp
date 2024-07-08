using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace IdentityMovie.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenreRepository _genreRepository;
        
        public GenreController(ApplicationDbContext dbContext, IGenreRepository genreRepository)
        {
            _dbContext = dbContext;
            _genreRepository = genreRepository; 
        }

        public IActionResult Index()
        {
            var getlist = _dbContext.Genres.ToList();
            return View(getlist);
        }

        [HttpGet]
        public  List<Genre> GetAll()
        {
            var genres =  _dbContext.Genres.ToList();
            return genres;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            var add = _genreRepository.AddGenre(genre);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            var edit = _genreRepository.UpdateGenre(genre);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var findid = _dbContext.Genres.Find(id);
        //    return View(findid);
        //}


        [HttpGet]
        public IActionResult Delete(Genre genre)
        {
            var remove = _genreRepository.DeleteGenre(genre.Id);
            return RedirectToAction("Index");
        }
    }
}
