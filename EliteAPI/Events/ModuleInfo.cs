namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleInfoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class ModuleInfoInfo
    {
        public static ModuleInfoInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeModuleInfoEvent(JsonConvert.DeserializeObject<ModuleInfoInfo>(json, EliteAPI.Events.ModuleInfoConverter.Settings));
    }

    public static class ModuleInfoSerializer
    {
        public static string ToJson(this ModuleInfoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleInfoConverter.Settings);
    }

    internal static class ModuleInfoConverter
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
