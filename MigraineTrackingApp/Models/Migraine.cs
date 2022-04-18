/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022 
 */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// gets and sets users migraine data from database
    /// </summary>
    public class Migraine
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
        [JsonProperty("foods")]
        public List<string> foods { get; set; }

        [JsonProperty("startDate")]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }
        [JsonProperty("startTime")]
        public string startTime { get; set; }

        [JsonProperty("endTime")]
        public string endTime { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }
        [JsonProperty("humidity")]
        public string humidity { get; set; }
        [JsonProperty("temperature")]
        public string temperature { get; set; }
        [JsonProperty("migraineDuration")]
        public string migraineDuration { get; set; }
        [JsonProperty("painIntensity")]
        public string painIntensity { get; set; }
        [JsonProperty("dateEntered")]
        public string dateEntered { get; set; }
    }
}
