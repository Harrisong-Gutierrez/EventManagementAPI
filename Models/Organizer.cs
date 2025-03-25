namespace EventManagementAPI.Models
{
    public class Organizer
    {
        public Guid OrganizerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
