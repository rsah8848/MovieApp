using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _ApplicationDBContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDBContext)
        {
            _logger = logger;
            _ApplicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public IActionResult Create(Genre genre)
        //{
        //    var view = _ApplicationDBContext.Genres.Add(genre);
        //    _ApplicationDBContext.SaveChanges();
        //    return View();
        //}
    }
} 