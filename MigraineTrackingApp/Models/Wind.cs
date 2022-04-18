/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/04/2022
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// used in setting variables returned from weather API
    /// </summary>
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}
