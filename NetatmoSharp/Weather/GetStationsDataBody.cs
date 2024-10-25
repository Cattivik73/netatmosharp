//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class GetStationsDataBody
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time_exec")]
        public double TimeExec { get; set; }

        [JsonProperty("time_server")]
        public long TimeServer { get; set; }
    }

}