using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;
using Microsoft.Extensions.Logging;

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
            try
            {
                return Ok(await repo.LogUserInAsync(username, hashedPassword));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            bool succes;
            try
            {
                succes = await repo.CreateUserAsync(user);
            }
            catch
            {
                return NotFound();
            }
            if (succes)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            bool succes = false;
            try
            {
                succes = await repo.DeleteUserAsync(userId);
            }
            catch
            {
                return NotFound();
            }
            if (succes)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            if (user != null)
            {
                bool succes;
                try
                {
                    succes = await repo.UpdateUserAsync(user);
                }
                catch
                {
                    return NotFound();
                }
                if (succes)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}