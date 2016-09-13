using System.Collections.Generic;
using Catagorization;
using Newtonsoft.Json;

namespace PeopleService.Domain.Models
{
    public class Owner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; } 

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("pets")]
        public ICollection<Pet> Pets { get; set; }
    }
}