namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class NavBeaconScanInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; set; }
    }

    public partial class NavBeaconScanInfo
    {
        public static NavBeaconScanInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeNavBeaconScanEvent(JsonConvert.DeserializeObject<NavBeaconScanInfo>(json, EliteAPI.Events.NavBeaconScanConverter.Settings));
    }

    public static class NavBeaconScanSerializer
    {
        public static string ToJson(this NavBeaconScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.NavBeaconScanConverter.Settings);
    }

    internal static class NavBeaconScanConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
