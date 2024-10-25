//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class Place
    {
        [JsonProperty("altitude")]
        public int Altitude { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("location")]
        public List<double> Location { get; set; }
    }

}