using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;

namespace EventManagementAPI.Services
{
  
    public interface ISponsorService
    {
        IEnumerable<Sponsor> GetAll();
        Sponsor GetById(Guid id);
        void AddSponsor(SponsorDto sponsorDTO);
        void UpdateSponsor(Guid id, SponsorDto sponsorDTO);
        void RemoveSponsor(Guid id);
    }

   
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorService(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public IEnumerable<Sponsor> GetAll() => _sponsorRepository.GetAll();

        public Sponsor GetById(Guid id) => _sponsorRepository.GetById(id);

        public void AddSponsor(SponsorDto sponsorDTO)
        {
            var sponsor = new Sponsor
            {
                SponsorId = Guid.NewGuid(),
                Name = sponsorDTO.Name,
                Description = sponsorDTO.Description,
                EventId = sponsorDTO.EventId

            };
            _sponsorRepository.Add(sponsor);
        }

        public void UpdateSponsor(Guid id, SponsorDto sponsorDTO)
        {
            var sponsor = _sponsorRepository.GetById(id);
            if (sponsor != null)
            {
                sponsor.Name = sponsorDTO.Name;
                _sponsorRepository.Update(sponsor);
            }
        }

        public void RemoveSponsor(Guid id) => _sponsorRepository.Delete(id);

    }
}
