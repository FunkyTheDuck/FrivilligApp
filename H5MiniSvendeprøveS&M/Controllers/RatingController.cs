using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;

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
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRatingAsync(int ratingId)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersRatingsAsync(int userId)
        {
            return Ok();
        }
    }
}