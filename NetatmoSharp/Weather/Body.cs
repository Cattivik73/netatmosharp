//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class Body
    {
        [JsonProperty("devices")]
        public List<Device> Devices { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

}