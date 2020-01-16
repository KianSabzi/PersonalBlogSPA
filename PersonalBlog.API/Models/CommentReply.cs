using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
    public class CommentReply
    {
         public int Id { get; set; }
        public string ReplyAutherName { get; set; }
        [Required]
        public string ReplyContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReplyTime { get; set; }
        public bool AdminReply { get; set; }
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}