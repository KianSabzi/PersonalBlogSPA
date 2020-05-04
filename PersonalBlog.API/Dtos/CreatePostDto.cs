using System;
using System.Collections.Generic;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Dtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }    
        public DateTime PubDate  { get; set; } = DateTime.Now;
        public string ArticleSource { get; set; }
        public List<Tag> Tags { get; set; }
    }
}