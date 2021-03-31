using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Director : Crew
    {
        [JsonIgnore]
        public ICollection<MovieDirector> MoviesLink { get; set; }
    }
}