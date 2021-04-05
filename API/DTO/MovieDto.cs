using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.DTO
{
    public class MovieDto
    {
        public int MovieId { get; set; } = 0;
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Storyline { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public IReadOnlyList<Writer> Writers { get; set; } = null;
        public IReadOnlyList<Actor> Actors { get; set; }  = null;
        public IReadOnlyList<Director> Directors { get; set; } = null;
    }
}