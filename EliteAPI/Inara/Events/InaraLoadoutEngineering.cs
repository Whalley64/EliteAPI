﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraLoadoutEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; internal set; }
        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; internal set; }
        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; internal set; }
        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; internal set; }
        [JsonProperty("modifiers")]
        public List<InaraModifier> Modifiers { get; internal set; }
    }
}