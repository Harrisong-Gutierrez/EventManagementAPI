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
        public ActionResult<Sponsor> Add(Sponsor sponsor)
        {
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
