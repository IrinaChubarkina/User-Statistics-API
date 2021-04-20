using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core.Abstractions.Services;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                user = await _userService.Add(user);
                var response = _mapper.Map<UserDto>(user);
            
                return Ok(response);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}