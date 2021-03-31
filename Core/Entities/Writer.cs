using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Writer : Crew
    {
        [JsonIgnore]
        public ICollection<MovieWriter> MoviesLink { get; set; }
    }
}