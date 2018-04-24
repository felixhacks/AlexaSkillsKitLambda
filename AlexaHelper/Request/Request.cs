using System.IO;

namespace AlexaHelper.Request
{
    public class Request
    {
        public Directive Directive { get; set; }

        public override string ToString()
        {
            string myString;
            var stream = new MemoryStream();

            var s = new Amazon.Lambda.Serialization.Json.JsonSerializer();
            s.Serialize(this, stream);
            stream.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(stream))
            {
                myString = reader.ReadToEnd();
            }

            return myString;
        }
    }
}
