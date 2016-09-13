using System.Collections.Generic;
using Newtonsoft.Json;

namespace Catagorization.Domain.Models
{
    public class PetByOwnerGender
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("names")]
        public IEnumerable<string> Names { get; set; }
    }
}