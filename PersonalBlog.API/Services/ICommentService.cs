using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public interface ICommentService
    {
       Task AddNewComment(Comment comment);
       Comment EditAuthorCommentByAdmin(int commentId ,int SiteAuthorId,Comment comment);
       bool ApproveComment(int id);
       void DeleteComment(int id);
       Task<IList<Comment>> GetAllComment();
       Task<IList<Comment>> GetAllPendingComment();
       Task<IList<Comment>> GetAllUnDeleteComment();
       Task<Comment> GetCommentById(int id);
       Task<IList<Comment>> GetAllPostComment(int postId);
       Task<IList<Comment>> GetAuthorPostComment(string username, int postId);

    }
}