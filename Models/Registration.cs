namespace EventManagementAPI.Models
{
    public class Registration
    {
        public Guid RegistrationId { get; set; } = Guid.NewGuid();
        public Guid EventId { get; set; } 
        public Guid ParticipantId { get; set; } 
        public DateTime RegistrationDate { get; set; }

        public Event Event { get; set; }
        public Participant Participant { get; set; }
    }
}
