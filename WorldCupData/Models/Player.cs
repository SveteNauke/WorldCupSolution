﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupData.Models
{
    public class Player
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int? ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }

        public string TeamCode { get; set; }
    }
}
