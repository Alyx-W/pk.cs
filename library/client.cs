using System;
using RestSharp;
using RestSharp.Authenticators;

namespace PluralkitCore
{
    /// <summary>
    /// The Client class that handles all requests.
    /// </summary>
    public class PKClient
    {
        RestClient client = new RestClient("https://api.pluralkit.me/v1/");

        public string GetSystem(string system)
        {   
            var length = system.Length;
            if (length == 5) { 
                var request = new RestRequest("s/{system}")
                    .AddUrlSegment("system", system);
            }
            if (length ==  17 || length == 18 || length == 19) { 
                var request = new RestRequest("a/{system}")
                    .AddUrlSegment("system", system);
            }
            
            var response = client.Get(request);
            switch (response.StatusCode) {
                case 404: 
                    throw new Exception("System not found.");
                case 403:
                    throw new Exception("Access denied.");
                case 401: 
                    throw new Exception("Unauthorized.");
            }
            return response.Content;
        }  
        public string GetMember(string member)
        {   
            var request = new RestRequest("m/{member}")
                .AddUrlSegment("member", member);
            var response = client.Get(request);
            switch (response.StatusCode) {
                case 404: 
                    throw new Exception("Member not found.");
                case 403:
                    throw new Exception("Access denied.");
                case 401: 
                    throw new Exception("Unauthorized.");
            }
            return response.Content;
        }

        public string GetSwitches(string system)
        {
            var request = new RestRequest("s/switches");

        }
    }
}