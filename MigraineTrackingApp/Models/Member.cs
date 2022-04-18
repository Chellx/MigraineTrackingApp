/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
 */

using Newtonsoft.Json;
using System;

namespace MigraineTrackingApp.Models
{
    /// <summary>
    /// gets and sets user profile data from database
    /// </summary>
    public class Member
    {
        [JsonProperty("email")]
        public String Email { get; set; } //variable

        [JsonProperty("firstName")]
        public String FirstName { get; set; } //variable

        [JsonProperty("gender")]
        public String Gender { get; set; } //variable

        [JsonProperty("dob")]
        public String Dob { get; set; } //variable
    }
}
