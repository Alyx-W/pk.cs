using System;
using RestSharp;
namespace PluralkitAPI
{
    namespace Errors
    {
        public class HttpError : Exception
        {
            public HttpError(IRestResponse response) : base($"Unexpected response. {response.StatusDescription}: {(int)response.StatusCode}")
            {
            }
        }
        public class Unauthorized : Exception
        {
            public Unauthorized() : base("Your token is missing and is required for this request.")
            {
            }
        }
        public class AccessForbidden: Exception
        {
            public AccessForbidden() : base("Your token does not correspond to the system whose private information you're attempting to fetch.")
            {
            }
        }
        public class SystemNotFound : Exception
        {
            public SystemNotFound() : base("There isn't a system associated with the token you passed.")
            {
            }
            public SystemNotFound(string id) : base($"{id} is not a valid system id.")
            {
            }
        }
        public class MemberNotFound : Exception
        {
            public MemberNotFound(string id) : base($"{id} is not a valid member id.")
            {
            }
        }
        public class DiscordUserNotFound : Exception
        {
            public DiscordUserNotFound(string id) : base($"{id} does not correspond to a discord user with a pluralkit system.")
            {
            }
        }
    }
}