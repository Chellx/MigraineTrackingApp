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
    /// returns JSON from openfoodfacts
    /// </summary>
    public class Product
    {
        [JsonProperty("product")] //key returned from JSON object
        public FoodName foodDetails { get; set; } //value stored here
    }
}
