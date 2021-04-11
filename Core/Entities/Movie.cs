using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }

        [JsonIgnore]
        public ICollection<MovieGenre> GenresLink { get; set; }

        [JsonIgnore]
        public ICollection<MovieWriter> WritersLink { get; set; }

        [JsonIgnore]
        public ICollection<MovieActor> ActorsLink { get; set; }
        
        [JsonIgnore]
        public ICollection<MovieDirector> DirectorsLink { get; set; }
    }
}
