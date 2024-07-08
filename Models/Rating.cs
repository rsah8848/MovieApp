namespace IdentityMovie.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Value { get; set; }
        public int MovieId { get; set;}

        public Guid UserId { get; set; }

    }
}
