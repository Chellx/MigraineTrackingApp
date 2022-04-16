/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using Newtonsoft.Json;
using System;

namespace MigraineTrackingApp.Models
{
    public class Member
    {
        [JsonProperty("email")]
        public String Email { get; set; } //property

        [JsonProperty("firstName")]
        public String FirstName { get; set; } //property

        [JsonProperty("gender")]
        public String Gender { get; set; } //property

        [JsonProperty("dob")]
        public String Dob { get; set; } //property
    }
}
