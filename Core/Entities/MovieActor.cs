using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class MovieActor
    {
       
        public int MovieId { get; set; }
        public int ActorId { get; set; }    
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}