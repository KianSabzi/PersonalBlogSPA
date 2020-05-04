using System;

namespace PersonalBlog.API.Dtos
{
    public class CommentListForViewDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int ParentCommentId { get; set; }
        public PostForViewDto Post { get; set; }
        public int PostId { get; set; }
    }
}