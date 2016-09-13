using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Catagorization.Domain.Models
{
    public class PetByOwnerGender
    {
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        [JsonProperty("names")]
        public IEnumerable<string> Names { get; set; }
    }
}