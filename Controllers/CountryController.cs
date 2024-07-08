using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
/*using IdentityMovie.Migrations;*/
using IdentityMovie.Models;
using IdentityMovie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IdentityMovie.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Country> countries = _countryRepository.GetAllCountries();
            return View(countries);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepository.AddCountry(country);
                TempData["SuccessMessages"] = "Country created sucessfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessages"] = "Model state is invalid";
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Country country)
        {
            _countryRepository.UpdateCountry(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Country country)
        {
           _countryRepository.DeleteCountry(country);
            return RedirectToAction("Index");
        }
    }
}
