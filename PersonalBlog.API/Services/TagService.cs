using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.API.Data;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public class TagService : ITagService
    {
        private readonly DbSet<Tag> _tags;
        private readonly IUnitOfWork _uow;
        public TagService(IUnitOfWork uow)
        {
            _uow = uow;
            _tags = _uow.Set<Tag>();

        }
        public void AddNewTag(Tag tag)
        {
            _tags.Add(tag);
        }
        public void AddBatchTag(Tag[] tag)
        {
            _tags.AddRange(tag);
        }
        public async Task<IList<Tag>> GetAllTags()
        {
             return await _tags.ToListAsync();
        }
        public async Task<Tag> GetTagById(int id)
        {
           return await _tags.FindAsync(id);
        }
        public async Task<IList<Tag>> GetAllTagsByPostId(int postId)
        {
            var tags = await _tags.FromSqlRaw("Select * From Tags Where PostId == @postId", postId).ToListAsync();
            return tags;
        }
        public void UpdateCurrentTag(int tagId, Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}