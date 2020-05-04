using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.API.Data;
using PersonalBlog.API.Dtos;
using PersonalBlog.API.Models;
using PersonalBlog.API.Services;

namespace PersonalBlog.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly ITagService _tagService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        
        

        public BlogController(IBlogService blogService, ICommentService commentService, IMapper mapper,
        IUnitOfWork uow, ITagService tagService)
        {
            _mapper = mapper;
            _blogService = blogService;
            _commentService = commentService;
            _tagService = tagService;
            _uow = uow;
        }


        [HttpGet("getposts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _blogService.GetAllPosts();
            var postsToReturn = _mapper.Map<IList<PostListForViewDto>>(posts);
            return Ok(postsToReturn);

        }
        [HttpGet("getpost/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _blogService.GetPostById(id);
            var postToReturn = _mapper.Map<PostForViewDto>(post);
            return Ok(postToReturn);
        }


        [HttpGet("getcomments")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _commentService.GetAllUnDeleteComment();
            var commentToReturn = _mapper.Map<IList<CommentListForViewDto>>(comments);

            return Ok(commentToReturn);
        }

        [HttpGet("getcomment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            var commentToReturn = _mapper.Map<CommentForViewDto>(comment);
            return Ok(commentToReturn);
        }

        [HttpPost("newcomment/{userId}")]
        public async Task<IActionResult> AddNewComment(int userId,CreateCommentDto newComment)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
            else
            {
            if(ModelState.IsValid)
            {
                var userName = User.FindFirstValue(ClaimTypes.Name);
                // var email = User.FindFirst(ClaimTypes.Email).Value;
                newComment.AuthorName = userName;
                var result = _mapper.Map<Comment>(newComment);
                // result.AuthorEmail = email;
                await _commentService.AddNewComment(result);
                await _uow.SaveChangesAsync();
                return Ok(result);
            }
            return BadRequest();    
            }
            
        }

    }
}