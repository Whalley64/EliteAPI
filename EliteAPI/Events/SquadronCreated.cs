namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SquadronCreatedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }
    }

    public partial class SquadronCreatedInfo
    {
        public static SquadronCreatedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeSquadronCreatedEvent(JsonConvert.DeserializeObject<SquadronCreatedInfo>(json, EliteAPI.Events.SquadronCreatedConverter.Settings));
    }

    public static class SquadronCreatedSerializer
    {
        public static string ToJson(this SquadronCreatedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SquadronCreatedConverter.Settings);
    }

    internal static class SquadronCreatedConverter
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
