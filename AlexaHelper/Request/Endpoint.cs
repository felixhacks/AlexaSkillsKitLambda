using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Request
{
    public class Endpoint
    {
        public dynamic Scope { get; set; }
        public string EndpointId { get; set; }
        Dictionary<string, string> Cookies { get; set; }
    }
}
