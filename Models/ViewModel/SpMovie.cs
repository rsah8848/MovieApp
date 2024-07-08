using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityMovie.Models.ViewModel
{
    public class SpMovie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Years { get; set; }
        public string GenreName { get; set; }
        public string Name { get; set; }

    }
}
