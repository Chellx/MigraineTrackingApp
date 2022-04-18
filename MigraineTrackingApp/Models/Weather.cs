/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 * Date: 18/4/2022
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// returns JSON objects from weather API
    /// </summary>
    public class Weather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
