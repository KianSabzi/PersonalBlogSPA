namespace PersonalBlog.API.Models
{
   public enum MediaType{
        image,
        video,
        other
    }
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MediaType Type { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public bool IsIndex { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}