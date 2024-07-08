using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityMovie.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Year Year { get; set; }

        [Required]
        public string Photo { get; set; }


        [ForeignKey("Year")]
        public int? YearId { get; set; }

        public Genre Genre { get; set; }
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        public Country Country { get; set; }    
        [ForeignKey("Country")]
        public int? CountryId { get; set; }

    }
}
