using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Actor : Crew 
    {
        [JsonIgnore]
        public ICollection<MovieActor> MoviesLink { get; set; }

    }
}