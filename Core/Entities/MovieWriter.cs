namespace Core.Entities
{
    public class MovieWriter
    {
        public int MovieId { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public Movie Movie { get; set; }
    }
}