using Newtonsoft.Json;

namespace MovieStar
{
    public class MovieStarDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("Sex")]
        public string Sex { get; set; }

        [JsonProperty("Nationality")]
        public string Nationality { get; set; }
    }
}