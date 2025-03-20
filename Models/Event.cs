
namespace EventManagementAPI.Models
{
    public class Event
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxCapacity { get; set; }
        public Guid OrganizerId { get; set; } 

        public Organizer Organizer { get; set; }
        public List<Registration> Registrations { get; set; } = new List<Registration>(); 
        public List<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
    }
}
