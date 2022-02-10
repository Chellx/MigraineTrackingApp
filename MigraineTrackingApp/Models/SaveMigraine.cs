using Newtonsoft.Json;
using System.Collections.Generic;

namespace MigraineTrackingApp.Models
{
    public class SaveMigraine
    {
        [JsonProperty("migraineType")]
        public List<string> migraineType { get; set; }

        [JsonProperty("painLocation")]
        public List<string> painLocation { get; set; }

        [JsonProperty("medicationType")]
        public List<string> medicationType { get; set; }

        [JsonProperty("symptoms")]
        public List<string> symptoms { get; set; }

        [JsonProperty("triggers")]
        public List<string> triggers { get; set; }

        [JsonProperty("startDate")]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }
    }
}
