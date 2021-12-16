using ProvaPratica.Application.Dtos;
using ProvaPratica.Application.Interfaces;
using ProvaPratica.Domain.Entities;
using ProvaPratica.Infrastructure.Interfaces;

namespace ProvaPratica.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<List<Person>> GetPersons() => _personRepository.GetAll();

        public Task<List<Person>> GetActivePersons() => _personRepository.GetActive();

        public Task<Person> GetPerson(Guid id) => _personRepository.GetById(id);

        public Task AddPerson(PersonDto person)
        {
            var value = new Person(person.FirstName, person.Age, person.Email, person.ExperienceYears);

            return _personRepository.Add(value);
        }

        public Task UpdatePerson(Guid id, PersonDto person)
        {
            var personEntity = _personRepository.GetById(id);

            var result = personEntity.GetAwaiter().GetResult();

            result.UpdateFirstName(person.FirstName);
            result.UpdateAge(person.Age);
            result.UpdateEmail(person.Email);
            result.UpdateExperienceYears(person.ExperienceYears);

            return _personRepository.Update(result);
        }

        public Task DeletePerson(Guid id)
        {
            var personEntity = _personRepository.GetById(id);

            var result = personEntity.GetAwaiter().GetResult();

            result.DesactivateData();

            return _personRepository.Update(result);
        }
    }
}
