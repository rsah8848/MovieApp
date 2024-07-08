using System.ComponentModel.DataAnnotations;

namespace IdentityMovie.Models
{
    public class Country
    {
        [Key] //Data Annotation
        public int Id { get; set; }
        public string Name { get; set; }

        public static bool IsDeleted { get; set; } = false;

        //public ICollection<Movie> Movie { get; set;}

    }
}
