namespace EventManagementAPI.DTOs
{
    public class RegistrationDto
    {
        public Guid RegistrationId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
