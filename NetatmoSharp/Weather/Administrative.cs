using Newtonsoft.Json;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class Administrative
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("reg_locale")]
        public string RegLocale { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("unit")]
        public int Unit { get; set; }

        [JsonProperty("windunit")]
        public int WindUnit { get; set; }

        [JsonProperty("pressureunit")]
        public int PressureUnit { get; set; }

        [JsonProperty("feel_like_algo")]
        public int FeelLikeAlgo { get; set; }
    }

}