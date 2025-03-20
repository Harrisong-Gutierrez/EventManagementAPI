using EventManagementAPI.Data;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    public interface IRegistrationRepository
    {
        IEnumerable<Registration> GetAll();
        Registration GetById(Guid registrationId);
        void Add(Registration registration);
        void Update(Registration registration);
        void Delete(Guid registrationId);
    }

    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly EventManagementContext _context;

        public RegistrationRepository(EventManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Registration> GetAll() => _context.Registrations.ToList();

        public Registration GetById(Guid registrationId) => _context.Registrations.Find(registrationId);

        public void Add(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        public void Update(Registration registration)
        {
            _context.Registrations.Update(registration);
            _context.SaveChanges();
        }

        public void Delete(Guid registrationId)
        {
            var registration = _context.Registrations.Find(registrationId);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                _context.SaveChanges();
            }
        }
    }
}
