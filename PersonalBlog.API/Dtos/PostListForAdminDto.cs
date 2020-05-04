using System;
using System.Collections.Generic;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Dtos
{
    public class PostListForAdminDto
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public bool IsPublished { get; set; }   
        public DateTime PubDate  { get; set; }
        public bool CommentOpen { get; set; }
        public string ArticleSource { get; set; }
        public int ViewCount { get; set; }
        public List<TagsForPostDto> Tags { get; set; }
        public List<AttachmentsForPostDto> Attachments { get; set; }
    }
}