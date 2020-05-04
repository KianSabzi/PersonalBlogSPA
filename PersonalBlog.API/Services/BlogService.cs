using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.API.Data;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Post> _posts;
        public BlogService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _posts = _uow.Set<Post>();
        }
        public void AddNewPost(Post post)
        {
            _posts.Add(post);
        }

        public async Task<IList<Post>> GetAllPosts()
        {
            return await _posts.Include(p=> p.Attachments).Include(p => p.Tags).ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _posts.Include(p=>p.Attachments).Include(p => p.Tags).Include(p => p.Comments).FirstOrDefaultAsync(u => u.Id == postId );
        }
    }
}