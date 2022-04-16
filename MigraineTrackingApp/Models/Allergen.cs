/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace MigraineTrackingApp.Models
{
    public class Allergen
    {
        [JsonProperty("allergenList")]
        public List<string> allergenList { get; set; }
    }
}
