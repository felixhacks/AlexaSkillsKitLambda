using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Response
{
    public class Endpoint
    {
        [JsonProperty("endpointId")]
        public string EndpointId { get; set; }
        [JsonProperty("friendlyName")]
        public string FriendlyName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("manufacturerName")]
        public string ManufacturerName { get; set; }
        [JsonProperty("displayCategories")]
        public IList<string> DisplayCategories { get; set; }
        [JsonProperty("cookie")]
        public Dictionary<string, string> Cookie { get; set; }
        [JsonProperty("capabilities")]
        public IList<Capability> Capabilities { get; set; }
        [JsonProperty("scope")]
        public Dictionary<string, string> Scope { get; set; }
    }
}
