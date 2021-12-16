using ProvaPratica.Application.Dtos;
using ProvaPratica.Domain.Entities;

namespace ProvaPratica.Application.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();

        Task<List<Person>> GetActivePersons();

        Task<Person> GetPerson(Guid id);

        Task AddPerson(PersonDto person);

        Task UpdatePerson(Guid id, PersonDto person);

        Task DeletePerson(Guid id);
    }
}
