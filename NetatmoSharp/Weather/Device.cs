//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class Device
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("station_name")]
        public string StationName { get; set; }

        [JsonProperty("date_setup")]
        public long DateSetup { get; set; }

        [JsonProperty("last_setup")]
        public long LastSetup { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("last_status_store")]
        public long LastStatusStore { get; set; }

        [JsonProperty("module_name")]
        public string ModuleName { get; set; }

        [JsonProperty("firmware")]
        public int Firmware { get; set; }

        [JsonProperty("last_upgrade")]
        public long LastUpgrade { get; set; }

        [JsonProperty("wifi_status")]
        public int WifiStatus { get; set; }

        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        [JsonProperty("co2_calibrating")]
        public bool Co2Calibrating { get; set; }

        [JsonProperty("data_type")]
        public List<string> DataType { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("home_id")]
        public string HomeId { get; set; }

        [JsonProperty("home_name")]
        public string HomeName { get; set; }

        [JsonProperty("dashboard_data")]
        public DashboardData DashboardData { get; set; }

        [JsonProperty("modules")]
        public List<Module> Modules { get; set; }
    }

}