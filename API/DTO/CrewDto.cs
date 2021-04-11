using System.Collections.Generic;
using Core.Entities;

namespace API.DTO
{
    public class CrewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Movie> MovieList { get; set; }
    }
}