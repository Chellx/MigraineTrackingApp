using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    public class FoodName
    {
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("allergens_from_ingredients")]
        public string Allergens { get; set; }
    }
}
