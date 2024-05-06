using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;

namespace H5MiniSvendeprøveS_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        InterestsRepository repo {  get; set; }
        public InterestsController()
        {
            repo = new InterestsRepository();
        }
        [HttpGet]
        public async Task<IActionResult> GetInterestsAsync()
        {
            try
            {
                return Ok(await repo.GetInterestsAsync());
            }
            catch
            {
                return NotFound();
            }
        }
    }
}