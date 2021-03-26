using System.Collections.Generic;

namespace Core.Entities
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string Name { get; set; }

         public ICollection<MovieWriter> MoviesLink { get; set; }
    }
}