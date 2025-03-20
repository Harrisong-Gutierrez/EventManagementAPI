using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Registration>> GetAll()
        {
            return Ok(_registrationRepository.GetAll());
        }

        [HttpGet("{registrationId}")]
        public ActionResult<Registration> GetById(Guid registrationId)
        {
            var registration = _registrationRepository.GetById(registrationId);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        [HttpPost]
        public ActionResult<Registration> Add(Registration registration)
        {
            _registrationRepository.Add(registration);
            return CreatedAtAction(nameof(GetById), new { registrationId = registration.ParticipantId }, registration);
        }

        [HttpPut("{registrationId}")]
        public ActionResult Update(Guid registrationId, Registration registration)
        {
            if (registrationId != registration.ParticipantId)
            {
                return BadRequest();
            }

            _registrationRepository.Update(registration);
            return NoContent();
        }

        [HttpDelete("{registrationId}")]
        public ActionResult Delete(Guid registrationId)
        {
            _registrationRepository.Delete(registrationId);
            return NoContent();
        }
    }
}
