﻿using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class ColorData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; }
    }
}
