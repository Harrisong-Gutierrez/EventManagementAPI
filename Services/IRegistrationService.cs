using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;

namespace EventManagementAPI.Services
{
    // Interfaz del servicio para Registration
    public interface IRegistrationService
    {
        IEnumerable<Registration> GetAll();
        Registration GetById(Guid registrationId); // Cambié 'id' a 'registrationId'
        void AddRegistration(RegistrationDto registrationDTO);
        void UpdateRegistration(Guid registrationId, RegistrationDto registrationDTO); // Cambié 'id' a 'registrationId'
        void RemoveRegistration(Guid registrationId); // Cambié 'id' a 'registrationId'
    }

    // Implementación del servicio para Registration
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public IEnumerable<Registration> GetAll() => _registrationRepository.GetAll();

        public Registration GetById(Guid registrationId) => _registrationRepository.GetById(registrationId);

        public void AddRegistration(RegistrationDto registrationDTO)
        {
            var registration = new Registration
            {
                RegistrationId = Guid.NewGuid(), 
                EventId = registrationDTO.EventId,
                ParticipantId = registrationDTO.ParticipantId,
                RegistrationDate = DateTime.UtcNow 
            };
            _registrationRepository.Add(registration);
        }

        public void UpdateRegistration(Guid registrationId, RegistrationDto registrationDTO)
        {
            var registration = _registrationRepository.GetById(registrationId);
            if (registration != null)
            {
                registration.EventId = registrationDTO.EventId;
                registration.ParticipantId = registrationDTO.ParticipantId;
                // Otros campos necesarios...
                _registrationRepository.Update(registration);
            }
        }

        public void RemoveRegistration(Guid registrationId) => _registrationRepository.Delete(registrationId);
    }
}
