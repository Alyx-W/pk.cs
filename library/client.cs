using System;
using Models;
using RestSharp;
using RestSharp.Authenticators;

namespace PluralkitCore
{
    /// <summary>
    /// The Client class that handles all requests.
    /// </summary>
    public class PKClient
    {
        public string? token;
        RestClient client = new RestClient("https://api.pluralkit.me/v1/");
        
        public Models.System GetSystem(string? system)
        {   
            IRestRequest request;
            if (system == null && token != null) { 
                request = new RestRequest("s/");
            } if (system.Length == 5 && system != null) {
                request = new RestRequest("s/{system}")
                    .AddUrlSegment("system", system);
            } if ((system.Length ==  17 || system.Length == 18 || system.Length == 19) && system != null) { 
                request = new RestRequest("a/{system}")
                    .AddUrlSegment("system", system);
            } else {
                throw new Exception("Must be a system ID, discord user ID, or null to use the system associated with the token you may have passed.");
            }
            
            var response = client.Get(request);
            switch (((int)response.StatusCode)) {
                case 404: 
                    throw new Exception("System not found.");
                case 403:
                    throw new Exception("Access denied.");
                case 401: 
                    throw new Exception("Unauthorized.");
            }
            return Models.System.FromJson(response.Content);
        }  /*
        public Models.System EditSystem() {
            
        } */
        public Models.Member GetMember(string member)
        {   
            var request = new RestRequest("m/{member}")
                .AddUrlSegment("member", member);
            var response = client.Get(request);
            switch (((int)response.StatusCode)) {
                case 404: 
                    throw new Exception("Member not found.");
                case 403:
                    throw new Exception("Access denied.");
                case 401: 
                    throw new Exception("Unauthorized.");
            }
            return Models.Member.FromJson(response.Content);
        }
        /*
        public string GetSwitches(string system)
        {
            var request = new RestRequest("s/switches");

        } */
    }
}