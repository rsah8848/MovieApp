using System.ComponentModel.DataAnnotations;

namespace IdentityMovie.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }    
        public ICollection<Movie> Movies { get; set;}
    }
}
