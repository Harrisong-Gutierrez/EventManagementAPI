using EventManagementAPI.DTOs; // Añade este using
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorController(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sponsor>> GetAll()
        {
            return Ok(_sponsorRepository.GetAll());
        }

        [HttpGet("{sponsorId}")]
        public ActionResult<Sponsor> GetById(Guid sponsorId)
        {
            var sponsor = _sponsorRepository.GetById(sponsorId);
            if (sponsor == null)
            {
                return NotFound();
            }
            return Ok(sponsor);
        }

        [HttpPost]
        public ActionResult<Sponsor> Add([FromBody] SponsorDto sponsorDto) // Cambia a SponsorDto
        {
            var sponsor = new Sponsor
            {
                SponsorId = Guid.NewGuid(),
                Name = sponsorDto.Name,
                Description = sponsorDto.Description,
                EventId = sponsorDto.EventId // Asigna directamente el ID
            };

            _sponsorRepository.Add(sponsor);
            return CreatedAtAction(nameof(GetById), new { sponsorId = sponsor.SponsorId }, sponsor);
        }

        [HttpPut("{sponsorId}")]
        public ActionResult Update(Guid sponsorId, Sponsor sponsor)
        {
            if (sponsorId != sponsor.SponsorId)
            {
                return BadRequest();
            }

            _sponsorRepository.Update(sponsor);
            return NoContent();
        }

        [HttpDelete("{sponsorId}")]
        public ActionResult Delete(Guid sponsorId)
        {
            _sponsorRepository.Delete(sponsorId);
            return NoContent();
        }
    }
}