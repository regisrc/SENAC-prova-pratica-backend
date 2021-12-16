using ProvaPratica.Domain.Entities;
using ProvaPratica.Infrastructure.Context;
using ProvaPratica.Infrastructure.Interfaces;

namespace ProvaPratica.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryAsync<Person>, IPersonRepository
    {
        public PersonRepository(ProvaPraticaContext context) : base(context)
        {
        }
    }
}
