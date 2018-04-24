using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Response
{
    public class Event
    {
        [JsonProperty("header")]
        public Request.Header Header { get; set; }
        [JsonProperty("payload")]
        public IResponsePayload Payload { get; set; }
    }
}
