namespace EventManagementAPI.DTOs
{
    public class SponsorDto
    {
        public Guid SponsorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EventId { get; set; }
    }
}
