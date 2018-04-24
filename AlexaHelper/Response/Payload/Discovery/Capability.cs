using Newtonsoft.Json;

namespace AlexaHelper.Response
{
    public class Capability
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("interface")]
        public string Interface { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        [JsonProperty("proactivelyReported")]
        public bool ProactivelyReported { get; set; }
        [JsonProperty("retrievable")]
        public bool Retrievable { get; set; }
    }
}