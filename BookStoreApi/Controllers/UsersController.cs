using BusinessObject.DTO.User;
using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await userRepository.Login(model);
            if(user!=null) return Ok(user);
            return BadRequest("Login failed");
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO model) 
        {
            var result = await userRepository.Register(model);
            if (!result)
            {
                return BadRequest("Email already existed");
            }
            return Ok("Register successfully");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userRepository.GetById(id);
            if (user != null) return Ok(user);
            else return NotFound("Cannot find user with id: " + id);
        } 
    }
}
