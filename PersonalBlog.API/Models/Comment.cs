using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        [Required]
        [EmailAddress]
        public string AuthorEmail { get; set; }
        [Required]
        [StringLength(250 , MinimumLength = 3)]
        public string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; }
        public int ParentCommentId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        
    }
}