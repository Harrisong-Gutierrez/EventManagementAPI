namespace EventManagementAPI.Models
{
    public class Sponsor
    {
        public Guid SponsorId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EventId { get; set; } 

        public Event Event { get; set; }
    }
}
