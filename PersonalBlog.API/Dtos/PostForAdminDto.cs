using System;
using System.Collections.Generic;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Dtos
{
    public class PostForAdminDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }    
        public DateTime PubDate  { get; set; }
        public string ArticleSource { get; set; }
        public int ViewCount { get; set; }
        public ICollection<TagsForPostDto> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<AttachmentsForPostDto> Attachments { get; set; }
    }
}