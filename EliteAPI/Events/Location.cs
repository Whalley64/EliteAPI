namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LocationInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Docked")]
        public bool Docked { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("StarPos")]
        public List<double> StarPos { get; set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; set; }

        [JsonProperty("Population")]
        public long Population { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }

        [JsonProperty("Factions")]
        public List<LocationFaction> Factions { get; set; }

        [JsonProperty("SystemFaction")]
        public string SystemFaction { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }
    }

    public partial class LocationFaction
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }

        [JsonProperty("Government")]
        public string Government { get; set; }

        [JsonProperty("Influence")]
        public double Influence { get; set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; set; }

        [JsonProperty("Happiness_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string HappinessLocalised { get; set; }

        [JsonProperty("MyReputation")]
        public double MyReputation { get; set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<LocationActiveState> ActiveStates { get; set; }

        [JsonProperty("PendingStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<LocationIngState> PendingStates { get; set; }

        [JsonProperty("RecoveringStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<LocationIngState> RecoveringStates { get; set; }
    }

    public partial class LocationActiveState
    {
        [JsonProperty("State")]
        public string State { get; set; }
    }

    public partial class LocationIngState
    {
        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Trend")]
        public long Trend { get; set; }
    }

    public partial class LocationInfo
    {
        public static LocationInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeLocationEvent(JsonConvert.DeserializeObject<LocationInfo>(json, EliteAPI.Events.LocationConverter.Settings));
    }

    public static class LocationSerializer
    {
        public static string ToJson(this LocationInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LocationConverter.Settings);
    }

    internal static class LocationConverter
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
