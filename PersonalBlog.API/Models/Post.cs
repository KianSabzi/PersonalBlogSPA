using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150,MinimumLength = 3)]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [StringLength(600 , MinimumLength = 3)]
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }    
        public bool IsPublished { get; set; }
        [DataType(DataType.Date)]
        public DateTime PubDate  { get; set; }
        public bool CommentOpen { get; set; }
        public string ArticleSource { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}