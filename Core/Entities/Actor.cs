using System.Collections.Generic;

namespace Core.Entities
{
    public class Actor 
    {
        public int ActorId { get; set; }
        public string Name { get; set; }

        public ICollection<MovieActor> MoviesLink { get; set; }

    }
}