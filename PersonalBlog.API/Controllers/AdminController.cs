using System.Collections.Generic;
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
    public class AdminController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AdminController(IBlogService blogService, IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            _blogService = blogService;
        }
        #region BlogManagement
        
        [HttpPost("newpost")]
        public IActionResult CreateNewPost(CreatePostDto newpost)
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<Post>(newpost);
                _blogService.AddNewPost(result);
                _uow.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("updatepost/{id}")]
        public async Task<IActionResult> UpdateCurrentPost(int id, UpdatePostDto updatepost)
        {
            if(ModelState.IsValid)
            {
                var postFromService = await _blogService.GetPostById(id);
                _mapper.Map(updatepost,postFromService);
                if(await _uow.SaveChangesAsync()>0)
                return NoContent();
                throw new System.Exception($"Updating post {id} failed on save");
            }
            return BadRequest();

        }

        [HttpPost("deletepost/{id}")]
        public async Task<IActionResult> DisablePost(int id)
        {
            if(id> 0)
            {
                var post = await _blogService.GetPostById(id);
                // IsDeleted attribute or shadow properties not impelemented yet!!
            }
            return BadRequest();
        }
                
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPostsForAdmin()
        {
            var posts = await _blogService.GetAllPosts();
            var postsToReturn = _mapper.Map<IList<PostListForAdminDto>>(posts);
            return Ok(postsToReturn);
        }
        [HttpGet("post/{id}")]
        public async Task<IActionResult> GetPostForAdmin(int id)
        {
            var post = await _blogService.GetPostById(id);
            var postToReturn = _mapper.Map<PostForAdminDto>(post);
            return Ok(postToReturn);
        }

        #endregion

    }
}