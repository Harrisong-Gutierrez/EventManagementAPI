using System.ComponentModel.DataAnnotations;

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

        // Aquí se requiere solo el OrganizerId
        [Required]  // Agregar esta anotación para validar que se requiere solo el OrganizerId
        public Guid OrganizerId { get; set; }

        // El objeto Organizer es opcional
        public Organizer? Organizer { get; set; } // Ahora es opcional

        public List<Registration> Registrations { get; set; } = new List<Registration>();
        public List<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
    }
}
