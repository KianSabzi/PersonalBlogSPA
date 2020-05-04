using System.Collections.Generic;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Dtos
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
         public string ArticleSource { get; set; }
        public IList<Tag> Tags { get; set; }


    }
}