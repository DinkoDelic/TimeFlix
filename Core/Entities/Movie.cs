using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Storyline { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public List<Writer> Writers { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
    }
}
