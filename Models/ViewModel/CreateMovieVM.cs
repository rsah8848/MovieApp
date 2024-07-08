using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityMovie.Models.ViewModel
{
    public class CreateMovieVM
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Year")]
        public int? YearId { get; set; }

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        [Display(Name = "Choose File")]
        public IFormFile ImagePath { get; set; }
    }
}

