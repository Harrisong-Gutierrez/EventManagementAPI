namespace EventManagementAPI.DTOs
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public Guid OrganizerId { get; set; }
    }
}
