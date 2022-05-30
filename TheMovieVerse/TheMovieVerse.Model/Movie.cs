using System;

namespace TheMovieVerse.Model
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDirector { get; set; }
        public string MovieGenre { get; set; }
        public string MovieRating { get; set; }
        public bool IsUpcoming { get; set; }
    }
}
