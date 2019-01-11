namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardNewInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; set; }
    }

    public partial class ShipyardNewInfo
    {
        public static ShipyardNewInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeShipyardNewEvent(JsonConvert.DeserializeObject<ShipyardNewInfo>(json, EliteAPI.Events.ShipyardNewConverter.Settings));
    }

    public static class ShipyardNewSerializer
    {
        public static string ToJson(this ShipyardNewInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardNewConverter.Settings);
    }

    internal static class ShipyardNewConverter
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
