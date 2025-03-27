using System.Text.Json.Serialization;

namespace EventManagementAPI.Models
{
    public class Participant
    {
        public Guid ParticipantId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [JsonIgnore]
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
