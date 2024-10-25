//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class DashboardData
    {
        [JsonProperty("time_utc")]
        public long TimeUtc { get; set; }

        [JsonProperty("Temperature")]
        public double Temperature { get; set; }

        [JsonProperty("CO2")]
        public int Co2 { get; set; }

        [JsonProperty("Humidity")]
        public int Humidity { get; set; }

        [JsonProperty("Noise")]
        public int Noise { get; set; }

        [JsonProperty("Pressure")]
        public double Pressure { get; set; }

        [JsonProperty("AbsolutePressure")]
        public double AbsolutePressure { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("date_max_temp")]
        public long DateMaxTemp { get; set; }

        [JsonProperty("date_min_temp")]
        public long DateMinTemp { get; set; }

        [JsonProperty("temp_trend")]
        public string TempTrend { get; set; }

        [JsonProperty("pressure_trend")]
        public string PressureTrend { get; set; }
    }

}