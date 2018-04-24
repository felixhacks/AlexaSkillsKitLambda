using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaHelper.Request
{
    public class Directive
    {
        public Header Header { get; set; }
        public Endpoint Endpoint { get; set; }
        public Context Context { get; set; }
        public dynamic Payload { get; set; }
    }
}
