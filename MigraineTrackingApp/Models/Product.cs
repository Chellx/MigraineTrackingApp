/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    public class Product
    {
        [JsonProperty("product")]
        public FoodName foodDetails { get; set; }
    }
}
