using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;

namespace H5MiniSvendeprøveS_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository repo {  get; set; }
        public UserController()
        {
            repo = new UserRepository();
        }
        [HttpGet]
        public async Task<IActionResult> LogUserInAsync(string username, string hashedPassword)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            return Ok();
        }
    }
}