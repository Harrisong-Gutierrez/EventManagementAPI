namespace EventManagementAPI.Models
{
    public class Participant
    {
        public Guid ParticipantId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
