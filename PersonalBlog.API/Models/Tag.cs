namespace PersonalBlog.API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}