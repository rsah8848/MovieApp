using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityMovie.Controllers
{

    public class YearController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public readonly IYearRepository _yearRepository;
        public YearController(ApplicationDbContext dbContext, IYearRepository yearRepository)
        {
            _dbContext = dbContext;
            _yearRepository = yearRepository;
        }

        public IActionResult Index()
        {
            var getlist = _dbContext.Years.ToList();
            return View(getlist);
        }

        [HttpGet]
        public List<Year> GetAll()
        {
            var genres = _dbContext.Years.ToList();
            return genres;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Year yearss)
        {
            var add = _yearRepository.AddYear(yearss);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Year yearss)
        {
            var edit = _yearRepository.UpdateYear(yearss);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(Year years)
        {
            var remove = _yearRepository.DeleteYear(years);
            return RedirectToAction("Index");
        }
    }
}
