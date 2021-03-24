using System.Collections.Generic;

namespace Core.Entities
{
    public class BasePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}