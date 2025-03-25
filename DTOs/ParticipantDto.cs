using EventManagementAPI.Models;

namespace EventManagementAPI.DTOs
{
    public class ParticipantDto
    {
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}

