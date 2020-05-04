using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public interface IBlogService
    {
         void AddNewPost(Post  post);
         Task<IList<Post>> GetAllPosts();
         Task<Post> GetPostById(int postId);
         
    }
}