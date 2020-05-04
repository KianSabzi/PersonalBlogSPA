using PersonalBlog.API.Models;

namespace PersonalBlog.API.Dtos
{
    public class AttachmentsForPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MediaType Type { get; set; }
        public string Path { get; set; }
        public bool IsIndex { get; set; }
    }
}