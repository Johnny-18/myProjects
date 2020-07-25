using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_.DTO;
using BLL_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService serv)
        {
            _commentService = serv;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _commentService.Get(id);
            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [HttpGet("id/{id}/user")]
        public async Task<IActionResult> GetUser(int id)
        {
            var comment = await _commentService.Get(id);
            if (comment == null)
                return NotFound();

            return Ok(comment.User);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody]CommentDTO comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var res = await _commentService.Create(comment);
            if (res)
            {
                return Ok(comment);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.Get(id);
            if (comment == null)
                return NotFound();

            var res = await _commentService.Remove(comment);
            if (res)
            {
                return Ok();
            }

            return BadRequest("Didn't deleted");
        }
    }
}
