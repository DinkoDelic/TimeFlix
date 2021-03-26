using System;
using System.Collections.Generic;

namespace API.DTO
{
    public class MovieToReturnDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Storyline { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public ICollection<string> Writers { get; set; }
        public ICollection<string> Actors { get; set; }  
        public ICollection<string> Directors { get; set; } 
    }
}