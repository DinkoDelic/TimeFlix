using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Genre: Crew
    {

        [JsonIgnore]
        public ICollection<MovieGenre> MoviesLink { get; set; }
    }
}