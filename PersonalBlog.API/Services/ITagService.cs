using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Services
{
    public interface ITagService
    {
        Task<IList<Tag>> GetAllTags();
        Task<Tag> GetTagById(int id);
        Task<IList<Tag>> GetAllTagsByPostId(int postId);
        void AddNewTag(Tag  tag);
        void AddBatchTag(Tag[] tag);
        void UpdateCurrentTag(int tagId,Tag tag);
        
    }
}