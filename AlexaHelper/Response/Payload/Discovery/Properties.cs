using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlexaHelper.Response
{
    public class Properties
    {
        [JsonProperty("supported")]
        public IList<Dictionary<string, string>> Supported { get; set; }
    }
}