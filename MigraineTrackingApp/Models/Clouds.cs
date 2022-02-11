using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
