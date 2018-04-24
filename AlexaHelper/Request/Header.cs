using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Request
{
    public class Header
    {
        [JsonProperty("namespace")]
        public string Namespace { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
        [JsonProperty("correlationToken")]
        public string CorrelationToken { get; set; }
        [JsonProperty("payloadVersion")]
        public string PayloadVersion { get; set; }
    }
}
