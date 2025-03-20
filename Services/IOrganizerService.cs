using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;

public interface IOrganizerService
{
    IEnumerable<Organizer> GetAll();
    Organizer GetById(Guid organizerId);
    void CreateOrganizer(OrganizerDto organizerDTO);
    void UpdateOrganizer(Guid organizerId, OrganizerDto organizerDTO);
    void DeleteOrganizer(Guid organizerId);
}

public class OrganizerService : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository;

    public OrganizerService(IOrganizerRepository organizerRepository)
    {
        _organizerRepository = organizerRepository;
    }

    public IEnumerable<Organizer> GetAll() => _organizerRepository.GetAll();

    public Organizer GetById(Guid organizerId) => _organizerRepository.GetById(organizerId);

    public void CreateOrganizer(OrganizerDto organizerDTO)
    {
        var organizer = new Organizer
        {
            OrganizerId = Guid.NewGuid(),
            Name = organizerDTO.Name,
            // Otros campos necesarios...
        };
        _organizerRepository.Add(organizer);
    }

    public void UpdateOrganizer(Guid organizerId, OrganizerDto organizerDTO)
    {
        var organizer = _organizerRepository.GetById(organizerId);
        if (organizer != null)
        {
            organizer.Name = organizerDTO.Name;
            // Otros campos necesarios...
            _organizerRepository.Update(organizer);
        }
    }

    public void DeleteOrganizer(Guid organizerId) => _organizerRepository.Delete(organizerId);
}
