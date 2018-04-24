using Newtonsoft.Json;
using System.IO;

namespace AlexaHelper.Response
{
    public class Response
    {
        [JsonProperty("event")]
        public Event Event { get; set; } = new Event();

        public override string ToString()
        {
            string myString;
            var stream = new MemoryStream();

            new Amazon.Lambda.Serialization.Json.JsonSerializer().Serialize(this, stream);
            stream.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(stream))
            {
                myString = reader.ReadToEnd();
            }

            return myString;
        }
    }
}
