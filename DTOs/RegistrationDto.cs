using EventManagementAPI.Models;

namespace EventManagementAPI.DTOs
{
    public class RegistrationDto
    {
        public Guid ParticipantId { get; set; }
        public Guid EventId { get; set; }
    }
}
