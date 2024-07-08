namespace IdentityMovie.Models.ViewModel
{
    public class CommentVM
    {
        public Guid CommentId { get; set; }
        public string? Text { get; set; }
        public string? UserName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
