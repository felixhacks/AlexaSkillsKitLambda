using System;

namespace AlexaHelper.Request
{
    public class Property
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfSample { get; set; }
        public int UncertainityInMilliseconds { get; set; }
        public dynamic Value { get; set; }
    }
}