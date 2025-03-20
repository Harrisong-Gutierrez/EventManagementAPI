using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;

public interface IEventService
{
    IEnumerable<Event> GetAll();
    Event GetById(Guid eventId);
    void CreateEvent(EventDto eventDTO);
    void UpdateEvent(Guid eventId, EventDto eventDTO);
    void DeleteEvent(Guid eventId);
}

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public IEnumerable<Event> GetAll()
    {
        return _eventRepository.GetAll();
    }

    public Event GetById(Guid eventId)
    {
        return _eventRepository.GetById(eventId);
    }

    public void CreateEvent(EventDto eventDTO)
    {
        var eventModel = new Event
        {
            EventId = Guid.NewGuid(),
            Name = eventDTO.Name,
            Date = eventDTO.Date
        };
        _eventRepository.Add(eventModel);
    }

    public void UpdateEvent(Guid eventId, EventDto eventDTO)
    {
        var eventModel = _eventRepository.GetById(eventId);
        if (eventModel != null)
        {
            eventModel.Name = eventDTO.Name;
            eventModel.Date = eventDTO.Date;
            _eventRepository.Update(eventModel);
        }
    }

    public void DeleteEvent(Guid eventId)
    {
        _eventRepository.Delete(eventId);
    }
}
