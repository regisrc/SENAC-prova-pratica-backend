using Microsoft.AspNetCore.Mvc;
using ProvaPratica.Application.Dtos;
using ProvaPratica.Application.Interfaces;
using ProvaPratica.Domain.Entities;

namespace ProvaPratica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("getAll")]
        public Task<List<Person>> Get() => _personService.GetPersons();

        [HttpGet("getActive")]
        public Task<List<Person>> GetActive() => _personService.GetActivePersons();

        [HttpGet("{id}")]
        public Task<Person> GetId(Guid id) => _personService.GetPerson(id);

        [HttpPost]
        public Task Post([FromBody] PersonDto personDto) => _personService.AddPerson(personDto);

        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] PersonDto personDto) => _personService.UpdatePerson(id, personDto);

        [HttpDelete("{id}")]
        public Task Delete(Guid id) => _personService.DeletePerson(id);
    }
}