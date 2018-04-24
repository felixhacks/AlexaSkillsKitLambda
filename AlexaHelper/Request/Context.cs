using System.Collections.Generic;

namespace AlexaHelper.Request
{
    public class Context
    {
        public IList<Property> Properties { get; set; } = new List<Property>();
    }
}