using EventManagementAPI.Data;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    // Interfaz del repositorio
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(Guid eventId);
        void Add(Event eventModel);
        void Update(Event eventModel);
        void Delete(Guid eventId);
    }

    // Implementación del repositorio
    public class EventRepository : IEventRepository
    {
        private readonly EventManagementContext _context;

        // Constructor que recibe el contexto de la base de datos
        public EventRepository(EventManagementContext context)
        {
            _context = context;
        }

        // Implementación de los métodos definidos en la interfaz
        public IEnumerable<Event> GetAll() => _context.Events.ToList();

        public Event GetById(Guid eventId) => _context.Events.Find(eventId);

        public void Add(Event eventModel)
        {
            _context.Events.Add(eventModel);
            _context.SaveChanges();
        }

        public void Update(Event eventModel)
        {
            _context.Events.Update(eventModel);
            _context.SaveChanges();
        }

        public void Delete(Guid eventId)
        {
            var eventModel = _context.Events.Find(eventId);
            if (eventModel != null)
            {
                _context.Events.Remove(eventModel);
                _context.SaveChanges();
            }
        }
    }
}
