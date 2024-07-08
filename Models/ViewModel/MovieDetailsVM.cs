
namespace IdentityMovie.Models.ViewModel

{
    public class MovieDetailsVM
    {
        public Movie? Movie { get; set; }
        public IEnumerable<CommentVM> Comments { get; set; }
        
        public Year Year { get; set; }
        public Genre Genre { get; set; }
        public Country Country { get; set; }


    }
}
