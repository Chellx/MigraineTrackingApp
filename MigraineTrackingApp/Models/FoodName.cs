/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// returns JSON from openfoodfacts
    /// </summary>
    public class FoodName
    {
        [JsonProperty("product_name")] //finds product name in JSON object
        public string ProductName { get; set; }
        [JsonProperty("allergens_from_ingredients")] //finds allergens from ingredients in JSON object
        public string Allergens { get; set; }
    }
}
