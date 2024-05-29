using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;
using Microsoft.Extensions.Logging;

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
            try
            {
                return Ok(await repo.GetOneEventAsync(eventId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEventAsync(Event events)
        {
            if (events != null) 
            {
                bool succes;
                try
                {
                    succes = await repo.UpdateEventAsync(events);
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
        public async Task<IActionResult> DeleteEventAsync(int eventId)
        {
            bool succes = false;
            try
            {
                succes = await repo.DeleteEventAsync(eventId);
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
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(Event events)
        {
            if (events != null)
            {
                bool succes;
                try
                {
                    succes = await repo.CreateEventAsync(events);
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
        [HttpGet]
        public async Task<IActionResult> GetFromUserInterests(int page, int userId, double locationX, double locationY)
        {
            try
            {
                return Ok(await repo.GetFromUserInteretsAsync(page, userId, locationX, locationY));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("AddVoluntary")]
        public async Task<IActionResult> AddVoluntaryToEvent(int userId, int eventId)
        {
            bool checkIfSucces;
            try
            {
                checkIfSucces = await repo.AddVoluntaryToEvent(userId, eventId);
            }
            catch
            {
                return NotFound();
            }
            if(checkIfSucces)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("Owners")]
        public async Task<IActionResult> GetOwnersEventsAsync(int userId)
        {
            try
            {
                return Ok(await repo.GetOwnersEventsAsync(userId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("Voluntary")]
        public async Task<IActionResult> GetVoluntarysEventsAsync(int userId)
        {
            try
            {
                return Ok(await repo.GetVoluntarysEventsAsync(userId));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}