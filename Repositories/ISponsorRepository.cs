using EventManagementAPI.Data;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    public interface ISponsorRepository
    {
        IEnumerable<Sponsor> GetAll();
        Sponsor GetById(Guid sponsorId);
        void Add(Sponsor sponsor);
        void Update(Sponsor sponsor);
        void Delete(Guid sponsorId);
    }

    public class SponsorRepository : ISponsorRepository
    {
        private readonly EventManagementContext _context;

        public SponsorRepository(EventManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Sponsor> GetAll() => _context.Sponsors.ToList();

        public Sponsor GetById(Guid sponsorId) => _context.Sponsors.Find(sponsorId);

        public void Add(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            _context.SaveChanges();
        }

        public void Update(Sponsor sponsor)
        {
            _context.Sponsors.Update(sponsor);
            _context.SaveChanges();
        }

        public void Delete(Guid sponsorId)
        {
            var sponsor = _context.Sponsors.Find(sponsorId);
            if (sponsor != null)
            {
                _context.Sponsors.Remove(sponsor);
                _context.SaveChanges();
            }
        }
    }
}
