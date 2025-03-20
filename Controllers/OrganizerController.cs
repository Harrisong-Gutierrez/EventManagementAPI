using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerRepository _organizerRepository;

        public OrganizerController(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Organizer>> GetAll()
        {
            return Ok(_organizerRepository.GetAll());
        }

        [HttpGet("{organizerId}")]
        public ActionResult<Organizer> GetById(Guid organizerId)
        {
            var organizer = _organizerRepository.GetById(organizerId);
            if (organizer == null)
            {
                return NotFound();
            }
            return Ok(organizer);
        }

        [HttpPost]
        public ActionResult<Organizer> Add(Organizer organizer)
        {
            _organizerRepository.Add(organizer);
            return CreatedAtAction(nameof(GetById), new { organizerId = organizer.OrganizerId }, organizer);
        }

        [HttpPut("{organizerId}")]
        public ActionResult Update(Guid organizerId, Organizer organizer)
        {
            if (organizerId != organizer.OrganizerId)
            {
                return BadRequest();
            }

            _organizerRepository.Update(organizer);
            return NoContent();
        }

        [HttpDelete("{organizerId}")]
        public ActionResult Delete(Guid organizerId)
        {
            _organizerRepository.Delete(organizerId);
            return NoContent();
        }
    }
}
