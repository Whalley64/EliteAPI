namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JoinACrewInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Captain")]
        public string Captain { get; set; }
    }

    public partial class JoinACrewInfo
    {
        public static JoinACrewInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeJoinACrewEvent(JsonConvert.DeserializeObject<JoinACrewInfo>(json, EliteAPI.Events.JoinACrewConverter.Settings));
    }

    public static class JoinACrewSerializer
    {
        public static string ToJson(this JoinACrewInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.JoinACrewConverter.Settings);
    }

    internal static class JoinACrewConverter
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
