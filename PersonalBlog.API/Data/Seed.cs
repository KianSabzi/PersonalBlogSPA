using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Data
{
    public class Seed
    {
        private readonly DbSet<Post> _posts;
        private readonly IUnitOfWork _uow;

        public Seed(AppDbContext context, IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
             _posts = _uow.Set<Post>();
        }

        public void SeedBlogs()
        {
            var postData = System.IO.File.ReadAllText("Data/BlogSeedData.json");
            var posts = JsonConvert.DeserializeObject<List<Post>>(postData);
            foreach (var post in posts)
            {
                _posts.Add(post);
                
            }
            _uow.SaveChanges();
        }
    }
}