namespace CatMemes.Models
{
    public class GiphyResponse
    {
        public Gif[] Data { get; set; }
    }

    public class Gif
    {
        public Images Images { get; set; }
    }

    public class Images
    {
        public Original Original { get; set; }
    }

    public class Original
    {
        public string Url { get; set; }
    }
}
