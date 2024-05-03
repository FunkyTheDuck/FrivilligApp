using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;

namespace H5MiniSvendeprøveS_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        EventRepository repo { get; set; }
        public EventController() 
        { 
            repo = new EventRepository();
        }
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetOneEventAsync(int eventId)
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEventAsync(Event events)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEventAsync(int eventId)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(Event events)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetFromUserInterests(int page, List<string> interests, string location)
        {
            return Ok();
        }
    }
}