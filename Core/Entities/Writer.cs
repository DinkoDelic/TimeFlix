using System.Collections.Generic;

namespace Core.Entities
{
    public class Writer : Crew
    {
        public int WriterId { get; set; }
        public string Name { get; set; }

         public ICollection<MovieWriter> MoviesLink { get; set; }
    }
}