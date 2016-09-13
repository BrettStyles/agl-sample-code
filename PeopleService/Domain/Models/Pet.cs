using Catagorization;
using Newtonsoft.Json;

namespace PeopleService.Domain.Models
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public PetType Type { get; set; }
    }
}