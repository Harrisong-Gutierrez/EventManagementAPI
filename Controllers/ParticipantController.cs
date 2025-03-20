using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantController(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participant>> GetAll()
        {
            return Ok(_participantRepository.GetAll());
        }

        [HttpGet("{participantId}")]
        public ActionResult<Participant> GetById(Guid participantId)
        {
            var participant = _participantRepository.GetById(participantId);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }

        [HttpPost]
        public ActionResult<Participant> Add(Participant participant)
        {
            _participantRepository.Add(participant);
            return CreatedAtAction(nameof(GetById), new { participantId = participant.ParticipantId }, participant);
        }

        [HttpPut("{participantId}")]
        public ActionResult Update(Guid participantId, Participant participant)
        {
            if (participantId != participant.ParticipantId)
            {
                return BadRequest();
            }

            _participantRepository.Update(participant);
            return NoContent();
        }

        [HttpDelete("{participantId}")]
        public ActionResult Delete(Guid participantId)
        {
            _participantRepository.Delete(participantId);
            return NoContent();
        }
    }
}
