namespace API.Helpers
{
    public class UserParams
    {
        public int CurrentPage { get; set; } = 1;
        public int Offset { get; set;} = 3;

        public string nameFilter { get; set; } = null;
    }
}