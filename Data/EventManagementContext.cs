using Microsoft.EntityFrameworkCore;
using EventManagementAPI.Models;

namespace EventManagementAPI.Data
{
    public class EventManagementContext : DbContext
    {
        public EventManagementContext(DbContextOptions<EventManagementContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Evento - Organizador (1 a 1)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany()
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación de clave compuesta para Registration (EventId + ParticipantId)
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.EventId, r.ParticipantId });

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Participant)
                .WithMany()
                .HasForeignKey(r => r.ParticipantId);

            // Relación Evento - Patrocinador (1 a muchos)
            modelBuilder.Entity<Sponsor>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Sponsors)
                .HasForeignKey(s => s.EventId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
