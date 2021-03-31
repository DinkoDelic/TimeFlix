namespace Core.Entities
{
    public abstract class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } = "images/PlaceholderImage.png";
    }
}