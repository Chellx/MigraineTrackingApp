/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 * Date: 18/04/2022
 */

using Newtonsoft.Json;
using System.Collections.Generic;


namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// Sets or gets list of allergens from database
    /// </summary>
    public class Allergen
    {
        [JsonProperty("allergenList")]
        public List<string> allergenList { get; set; }
    }
}
