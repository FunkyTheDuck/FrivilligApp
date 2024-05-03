using Microsoft.AspNetCore.Mvc;
using ApiRepository;

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
    }
}