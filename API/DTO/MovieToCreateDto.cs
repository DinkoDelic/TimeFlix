using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.DTO
{
    public class MovieToCreateDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Storyline { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public ICollection<Writer> Writers { get; set; }
        public ICollection<Actor> Actors { get; set; }  
        public ICollection<Director> Directors { get; set; } 
    }
}