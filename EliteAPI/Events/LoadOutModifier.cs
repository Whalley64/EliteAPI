using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LoadOutModifier
    {
        [JsonProperty("Label")]
        public string Label { get; internal set; }

        [JsonProperty("Value")]
        public float Value { get; internal set; }

        [JsonProperty("OriginalValue")]
        public float OriginalValue { get; internal set; }

        [JsonProperty("LessIsGood")]
        public long LessIsGood { get; internal set; }
    }
}