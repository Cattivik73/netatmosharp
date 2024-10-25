//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class User
    {
        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("administrative")]
        public Administrative Administrative { get; set; }
    }

}