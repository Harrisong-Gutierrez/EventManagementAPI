using EventManagementAPI.Models;

namespace EventManagementAPI.DTOs
{
    public class RegistrationDto
    {
        public Guid RegistrationId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Event Event { get; set; }
        public Participant Participant { get; set; }
    }
}
