using IdentityMovie.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityMovie.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public string? Text { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
       // public ApplicationUser? User { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        //public Movie? Movie { get; set; }
        public DateTime? CreatedAt { get; set; }


    }
}
