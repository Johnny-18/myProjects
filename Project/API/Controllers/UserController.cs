using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("GetUser")]
        [Route("{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetAll();
            if (users == null)
                return NotFound();

            return Ok(users);
        }
    }
}
