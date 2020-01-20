using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MassModuleStoreInfo : IEvent
    {
        internal static MassModuleStoreInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMassModuleStoreEvent(JsonConvert.DeserializeObject<MassModuleStoreInfo>(json, EliteAPI.Events.MassModuleStoreConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("Items")]
        public List<Item> Items { get; internal set; }
    }
}
