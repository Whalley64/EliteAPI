namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SRVDestroyedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class SRVDestroyedInfo
    {
        public static SRVDestroyedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeSRVDestroyedEvent(JsonConvert.DeserializeObject<SRVDestroyedInfo>(json, EliteAPI.Events.SRVDestroyedConverter.Settings));
    }

    public static class SRVDestroyedSerializer
    {
        public static string ToJson(this SRVDestroyedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SRVDestroyedConverter.Settings);
    }

    internal static class SRVDestroyedConverter
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
