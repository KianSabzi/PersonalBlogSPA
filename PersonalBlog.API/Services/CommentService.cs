using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.API.Data;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Comment> _comments;
        public CommentService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _comments = _uow.Set<Comment>(); 

        }
        public async Task AddNewComment(Comment comment)
        {
            await _comments.AddAsync(comment);
        }
        public bool ApproveComment(int id)
        {
            var comment = _comments.Find(id);
            return comment.IsApproved = true;

        }
        public void DeleteComment(int id)
        {
            var comment = _comments.Find(id);
            comment.IsDeleted = true;
        }
        public Comment EditAuthorCommentByAdmin(int commentId, int SiteAuthorId, Comment comment)
        {
            throw new System.NotImplementedException();
        }
        public async Task<IList<Comment>> GetAllComment()
        {
            return await _comments.ToListAsync();
        }
        public async Task<IList<Comment>> GetAllPendingComment()
        {
             return await _comments.FromSqlRaw("Select * From Comments Where IsApproved == false").ToListAsync();
        }
        public async Task<IList<Comment>> GetAllUnDeleteComment()
        {
            return await _comments.FromSqlRaw("Select * From Comments Where IsDeleted == false").ToListAsync();
        }
        public async Task<Comment> GetCommentById(int id)
        {
            return await _comments.FindAsync(id);
        }
        public async Task<IList<Comment>> GetAllPostComment(int postId)
        {
            var comments = await _comments.FromSqlRaw("Select * From Comments Where PostId == @postId", postId).ToListAsync();
            return comments;
        }
        public async Task<IList<Comment>> GetAuthorPostComment(string username , int postId)
        {
            var comments = await _comments.FromSqlRaw("Select * From Comments Where AuthorName == @username AND PostId == @postId",username,postId).ToListAsync();
            return comments;
        }

        
    }
}