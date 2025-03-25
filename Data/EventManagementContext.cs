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
            // Relación Evento (N) -> Organizador (1)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events) // Relación bidireccional
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Inscripción (N) -> Evento (1)
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            // Relación Inscripción (N) -> Participante (1) (¡Actualizado!)
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Registrations) // Usa la nueva propiedad en Participant
                .HasForeignKey(r => r.ParticipantId);

            // Relación Patrocinador (N) -> Evento (1)
            modelBuilder.Entity<Sponsor>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Sponsors)
                .HasForeignKey(s => s.EventId);

            base.OnModelCreating(modelBuilder);
        }
    }
}