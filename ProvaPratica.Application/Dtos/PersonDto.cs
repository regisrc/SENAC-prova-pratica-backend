using Newtonsoft.Json;

namespace ProvaPratica.Application.Dtos
{
    public class PersonDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("experienceYears")]
        public int ExperienceYears { get; set; }
    }
}
