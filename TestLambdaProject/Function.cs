using AlexaHelper.Request;
using AlexaHelper.Response;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.IO;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace TestLambdaProject
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Response FunctionHandler(Request input, ILambdaContext context)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                context.Logger.LogLine("Got input: " + Stringify(input));

                if (input.Directive.Header.Namespace == "Alexa.Discovery" && input.Directive.Header.Name == "Discover")
                {
                    context.Logger.LogLine("Received discovery");
                    return Discovery(context);
                }

                throw new Exception("Input did not match any action");
            }
            catch (Exception e)
            {
                context.Logger.Log("Exception: " + e);
                throw e;
            }
        }

        public Response Discovery(ILambdaContext context)
        {
            context.Logger.LogLine("Doing discovery");

            Response response = new Response();

            response.Event.Header = new Header()
            {
                Namespace = "Alexa.Discovery",
                Name = "Discover.Response",
                PayloadVersion = "3",
                MessageId = Guid.NewGuid().ToString()
            };
            response.Event.Payload = GetDiscoveryPayload();

            context.Logger.LogLine("Giving output: " + response);
            return response;
        }

        public DiscoveryPayload GetDiscoveryPayload()
        {
            return new DiscoveryPayload()
            {
                Endpoints = new List<AlexaHelper.Response.Endpoint>
                    {
                        new AlexaHelper.Response.Endpoint()
                        {
                            EndpointId = "Appliance_1",
                            FriendlyName = "Test switch",
                            Description = "This is a test appliance",
                            ManufacturerName = "Just a sample",
                            DisplayCategories = new List<string> { "LIGHT" },
                            Cookie = new Dictionary<string, string>(),
                            Capabilities = new List<Capability>
                            {
                                new Capability()
                                {
                                    Type = "AlexaInterface",
                                    Interface = "Alexa.PowerController",
                                    Version = "3",
                                    Properties = new Properties()
                                    {
                                        Supported = new List<Dictionary<string, string>> {
                                            new Dictionary<string, string>
                                            {
                                                ["name"] = "powerState"
                                            }
                                        }
                                    },
                                    ProactivelyReported = true,
                                    Retrievable = true
                                }
                            }
                        }
                    }
            };
        }

        private string Stringify(object o)
        {
            string myString;
            var stream = new MemoryStream();

            new Amazon.Lambda.Serialization.Json.JsonSerializer().Serialize(o, stream);
            stream.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(stream))
            {
                myString = reader.ReadToEnd();
            }

            return myString;
        }
    }
}
