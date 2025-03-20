using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;

public interface IParticipantService
{
    IEnumerable<Participant> GetAll();
    Participant GetById(Guid participantId);
    void CreateParticipant(ParticipantDto participantDTO);
    void UpdateParticipant(Guid participantId, ParticipantDto participantDTO);
    void DeleteParticipant(Guid participantId);
}

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;

    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public IEnumerable<Participant> GetAll() => _participantRepository.GetAll();

    public Participant GetById(Guid participantId) => _participantRepository.GetById(participantId);

    public void CreateParticipant(ParticipantDto participantDTO)
    {
        var participant = new Participant
        {
            ParticipantId = Guid.NewGuid(),
            Name = participantDTO.Name,
        };
        _participantRepository.Add(participant);
    }

    public void UpdateParticipant(Guid participantId, ParticipantDto participantDTO)
    {
        var participant = _participantRepository.GetById(participantId);
        if (participant != null)
        {
            participant.Name = participantDTO.Name;
            _participantRepository.Update(participant);
        }
    }

    public void DeleteParticipant(Guid participantId) => _participantRepository.Delete(participantId);
}
