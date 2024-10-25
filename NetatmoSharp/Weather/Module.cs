//using NetatmoSharp.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
namespace NetatmoSharp.Weather
{
    public class Module
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("module_name")]
        public string ModuleName { get; set; }

        [JsonProperty("last_setup")]
        public long LastSetup { get; set; }

        [JsonProperty("data_type")]
        public List<string> DataType { get; set; }

        [JsonProperty("battery_percent")]
        public int BatteryPercent { get; set; }

        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        [JsonProperty("firmware")]
        public int Firmware { get; set; }

        [JsonProperty("last_message")]
        public long LastMessage { get; set; }

        [JsonProperty("last_seen")]
        public long LastSeen { get; set; }

        [JsonProperty("rf_status")]
        public int RfStatus { get; set; }

        [JsonProperty("battery_vp")]
        public int BatteryVp { get; set; }

        [JsonProperty("dashboard_data")]
        public DashboardData DashboardData { get; set; }
    }

}