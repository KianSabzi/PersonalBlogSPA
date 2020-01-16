using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
    public class Comment
    {
           public int Id { get; set; }
        [Required]
        [StringLength(50 , MinimumLength = 3)]
        public string Title { get; set; }
        public string AutherName { get; set; }
        [Required]
        [EmailAddress]
        public string AutherEmail { get; set; }
        [Required]
        [StringLength(250 , MinimumLength = 3)]
        public string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public ICollection<CommentReply> CommentReplies { get; set; }
    }
}