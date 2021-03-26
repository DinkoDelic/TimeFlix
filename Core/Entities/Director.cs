using System.Collections.Generic;

namespace Core.Entities
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public ICollection<MovieDirector> MoviesLink { get; set; }
    }
}