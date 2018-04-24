using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Response
{
    public class DiscoveryPayload : IResponsePayload
    {
        [JsonProperty("endpoints")]
        public IList<Endpoint> Endpoints { get; set; }
    }
}
