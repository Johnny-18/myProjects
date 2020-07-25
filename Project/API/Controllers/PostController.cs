using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IMapper _mapper;
        private IPostService _postService;
        private ILikeService _likeService;

        public PostController(
            IMapper mapper, 
            IPostService postService, 
            ILikeService likeService)
        {
            _mapper = mapper;
            _postService = postService;
            _likeService = likeService;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpGet("id/{id}/comments")]
        public async Task<IActionResult> GetComments(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post.Comments);
        }

        [HttpGet("id/{id}/likes")]
        public async Task<IActionResult> GetLikes(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post.Likes);
        }

        [HttpGet("id/{id}/images")]
        public async Task<IActionResult> GetImages(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post.Images);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            var searchStr = Request.Query["search"];

            var posts = await _postService.Search(searchStr);
            if (posts == null)
                return NotFound();

            return Ok(posts);
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]PostDTO newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var res = await _postService.Create(newPost);
            if (res)
            {
                return CreatedAtRoute("GetPost", new { id = newPost.Id}, newPost);
            }

            return BadRequest();
        }

        [Authorize(Roles = "Moderator")]
        [HttpPut]
        public async Task<IActionResult> ChangePost([FromBody]PostDTO updatedPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var res = await _postService.Update(updatedPost);
            if (res)
            {
                return Ok(updatedPost);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut("id/{id}")]
        public async Task<IActionResult> SetLike(int id)
        {
            var user_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            var res = await _likeService.SetLike(user_id, id);
            if (res)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut("id/{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var user_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();

            var res = await _likeService.DeleteLike(user_id, id);
            if (res)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postService.Get(id);
            if (post.Blog_Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return BadRequest();

            if (post == null)
                return NotFound();

            var res = await _postService.Remove(id);
            if (res)
            {
                return Ok("Deleted");
            }

            return BadRequest("Didn't deleted");
        }
    }
}
