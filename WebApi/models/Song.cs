namespace WebApi.models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }

        public int Duration { get; set; }
    }
}
