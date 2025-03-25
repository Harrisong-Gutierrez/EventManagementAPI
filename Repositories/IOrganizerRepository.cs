using EventManagementAPI.Data;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public interface IOrganizerRepository
    {
        IEnumerable<Organizer> GetAll();
        Organizer GetById(Guid organizerId);
        void Add(Organizer organizer);
        void Update(Organizer organizer);
        void Delete(Guid organizerId);
    }

    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly EventManagementContext _context;

        public OrganizerRepository(EventManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Organizer> GetAll() =>
       _context.Organizers
           .Include(o => o.Events)  // Incluir Eventos
           .ToList();

        public Organizer GetById(Guid organizerId) =>
       _context.Organizers
           .Include(o => o.Events)   // Incluir Eventos
           .FirstOrDefault(o => o.OrganizerId == organizerId);


        public void Add(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            _context.SaveChanges();
        }

        public void Update(Organizer organizer)
        {
            _context.Organizers.Update(organizer);
            _context.SaveChanges();
        }

        public void Delete(Guid organizerId)
        {
            var organizer = _context.Organizers.Find(organizerId);
            if (organizer != null)
            {
                _context.Organizers.Remove(organizer);
                _context.SaveChanges();
            }
        }
    }
}
