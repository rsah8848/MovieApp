using System.ComponentModel.DataAnnotations;

namespace IdentityMovie.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        public string Years { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
