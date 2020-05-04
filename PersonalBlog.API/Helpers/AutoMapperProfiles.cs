using System.Linq;
using AutoMapper;
using PersonalBlog.API.Dtos;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
      public AutoMapperProfiles()
      {
          CreateMap<Post,PostListForViewDto>();
          CreateMap<Post,PostForViewDto>();
          CreateMap<Post,PostListForAdminDto>();        
          CreateMap<Post,PostForAdminDto>();
          CreateMap<Attachment,AttachmentsForPostDto>();
          CreateMap<Tag,TagsForPostDto>();
          CreateMap<CreatePostDto,Post>();
          CreateMap<UpdatePostDto,Post>();

          CreateMap<Comment,CommentListForViewDto>();
          CreateMap<Comment,CommentForViewDto>();
          CreateMap<CreateCommentDto,Comment>()
              .ForMember(dest => dest.CommentDate, opt => opt.MapFrom(cm => cm.CreateAt));
                           
      }
    }
}