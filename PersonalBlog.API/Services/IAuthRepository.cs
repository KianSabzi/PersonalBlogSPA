using System.Threading.Tasks;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public interface IAuthRepository
    {
         Task<User> Register(User user , string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}