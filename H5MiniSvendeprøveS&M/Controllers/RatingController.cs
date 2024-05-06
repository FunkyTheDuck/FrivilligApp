using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;
using Microsoft.Extensions.Logging;

namespace H5MiniSvendeprøveS_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        RatingRepository repo {  get; set; }
        public RatingController()
        {
            repo = new RatingRepository();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRatingAsync(Ratings rating)
        {
            if (rating != null)
            {
                bool succes;
                try
                {
                    succes = await repo.CreateRatingAsync(rating);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteRatingAsync(int ratingId)
        {
            bool succes = false;
            try
            {
                succes = await repo.DeleteRatingAsync(ratingId);
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
        [HttpGet]
        public async Task<IActionResult> GetUsersRatingAsync(int userId)
        {
            try
            {
                return Ok(await repo.GetUsersRatingAsync(userId));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}