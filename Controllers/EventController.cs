using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            return Ok(_eventRepository.GetAll());
        }

        [HttpGet("{eventId}")]
        public ActionResult<Event> GetById(Guid eventId)
        {
            var eventItem = _eventRepository.GetById(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }
            return Ok(eventItem);
        }

        [HttpPost]
        public ActionResult<Event> Add(Event eventModel)
        {
            _eventRepository.Add(eventModel);
            return CreatedAtAction(nameof(GetById), new { eventId = eventModel.EventId }, eventModel);
        }

        [HttpPut("{eventId}")]
        public ActionResult Update(Guid eventId, Event eventModel)
        {
            if (eventId != eventModel.EventId)
            {
                return BadRequest();
            }

            _eventRepository.Update(eventModel);
            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public ActionResult Delete(Guid eventId)
        {
            _eventRepository.Delete(eventId);
            return NoContent();
        }
    }
}
