﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTrackingApp.Models
{
    public class Member
    {
        [JsonProperty("email")]
        public String Email { get; set; } //property


        [JsonProperty("firstName")]
        public String FirstName { get; set; } //property

        [JsonProperty("lastName")]
        public String LastName { get; set; } //property


        [JsonProperty("gender")]
        public String Gender { get; set; } //property

        [JsonProperty("dob")]
        public String Dob { get; set; } //property
    }
}
