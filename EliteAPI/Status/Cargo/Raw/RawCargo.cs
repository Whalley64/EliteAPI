﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EliteAPI.Status.Cargo.Raw
{
    internal class RawCargo
    {
        [JsonProperty("Vessel")]
        public string Vessel { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoItem> Inventory { get; set; }
    }
}