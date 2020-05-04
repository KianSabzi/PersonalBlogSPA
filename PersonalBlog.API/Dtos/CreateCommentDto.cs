using System;

namespace PersonalBlog.API.Dtos
{
    public class CreateCommentDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now.Date;
        public int ParentId { get; set; }
        public int PostId { get; set; }
        public PostForViewDto Post { get; set; }        
    }
}