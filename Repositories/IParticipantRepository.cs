using EventManagementAPI.Data;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    public interface IParticipantRepository
    {
        IEnumerable<Participant> GetAll();
        Participant GetById(Guid participantId);
        void Add(Participant participant);
        void Update(Participant participant);
        void Delete(Guid participantId);
    }

    public class ParticipantRepository : IParticipantRepository
    {
        private readonly EventManagementContext _context;

        public ParticipantRepository(EventManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Participant> GetAll() => _context.Participants.ToList();

        public Participant GetById(Guid participantId) => _context.Participants.Find(participantId);

        public void Add(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }

        public void Update(Participant participant)
        {
            _context.Participants.Update(participant);
            _context.SaveChanges();
        }

        public void Delete(Guid participantId)
        {
            var participant = _context.Participants.Find(participantId);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
        }
    }
}
