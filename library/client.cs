using System;
using PluralkitAPI.Models;
using PluralkitAPI.Errors;
using RestSharp;
using Newtonsoft.Json;

namespace PluralkitAPI
{
    namespace Client
    {
        /// <summary>
        /// The Client class that handles all requests.
        /// </summary>
        /// <param name="token">
        /// A system's pluralkit authorization token. Optional.
        /// </param>
        public class PKClient
        {
            private readonly string? token;
            private IRestClient Client { get; set; }

            public PKClient(string? token)
            {

                this.token = token ?? "null";
                Client = new RestClient("https://api.pluralkit.me/v1/")
                    .AddDefaultHeader("Authorization", this.token);
            }

            /// <summary>
            /// Fetches the specified system.
            /// </summary>
            /// <param name="system">
            /// The system to fetch, can be a discord snowflake id, a pluralkit system id, or null(to fetch the system associated with the authorization token passed).
            /// </param>
            /// <returns>
            /// The fetched <see cref="Models.System"/> object.
            /// </returns>
            public Models.System GetSystem(string? system)
            {
                IRestRequest? request = system == null && token != null
                    ? new RestRequest("s/")
                    : system != null
                        ? system.Length == 5
                                            ? new RestRequest("s/{system}")
                                                .AddUrlSegment("system", system)
                                            : system.Length == 17 || system.Length == 18 || system.Length == 19
                                                ? new RestRequest("a/{system}")
                                                                        .AddUrlSegment("system", system)
                                                : throw new Exception("Must be a system ID, discord user ID, or null to use the system associated with the token you may have passed.")
                        : throw new Exception("Must be a system ID, discord user ID, or null to use the system associated with the token you may have passed.");
                IRestResponse? response = Client.Get(request);
                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Models.System>(response.Content);
                    case 404:
                        if (token == null)
                        {
                            throw new SystemNotFound();
                        }
                        else
                        {
                            throw new SystemNotFound(system);
                        }
                    default:
                        throw new HttpError(response);
                };
            }

            /// <summary>
            /// Edits the system associated with the token passed.
            /// </summary>
            /// <param name="system">
            /// The <see cref="System"/> object to change your system to match.
            /// </param>
            /// <returns>
            /// The updated <see cref="System"/> object.
            /// </returns>
            public Models.System SetSystem(Models.System system)
            {
                IRestRequest? request = new RestRequest("s/")
                    .AddJsonBody(JsonConvert.SerializeObject(system))
                    .AddHeader("Content-Type", "application/json");

                IRestResponse? response = Client.Patch(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Models.System>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        throw new SystemNotFound(system.ID);
                    default:
                        throw new HttpError(response);
                };
            }

            /// <summary>
            /// Fetches the switches of the system.
            /// </summary>
            /// <param name="system">
            /// The <see cref="Models.System.ID"/> of the system.
            /// </param>
            /// <returns>
            /// The fetched <see cref="Switches"/> object.
            /// </returns>
            public Switches GetSwitches(string system)
            {
                IRestRequest? request = new RestRequest("s/{id}/switches/")
                    .AddUrlSegment("id", system);

                IRestResponse? response = Client.Get(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Switches>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        try
                        {
                            Models.System? validation_system = GetSystem(system);
                        }
                        catch (SystemNotFound)
                        {
                            throw new SystemNotFound(system);
                        }
                        return JsonConvert.DeserializeObject<Switches>(response.Content);
                    default:
                        throw new HttpError(response);
                }
            }

            /// <summary>
            /// Fetches the current fronters of a system.
            /// </summary>
            /// <param name="system">
            /// The <see cref="Models.System.ID"/> of the system.
            /// </param>
            /// <returns>
            /// A <see cref="Fronters"/>object.
            /// </returns>

            public Fronters GetFronters(string system)
            {

                IRestRequest? request = new RestRequest("s/{id}/fronters/")
                    .AddUrlSegment("id", system);

                IRestResponse? response = Client.Get(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Fronters>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        try
                        {
                            Models.System? validation_system = GetSystem(system);
                        }
                        catch (SystemNotFound)
                        {
                            throw new SystemNotFound(system);
                        }
                        return JsonConvert.DeserializeObject<Fronters>(response.Content);
                    default:
                        throw new HttpError(response);
                }
            }

            /// <summary>
            /// Gets the specified member.
            /// </summary>
            /// <param name="member">
            /// The <see cref="Member.ID"/> of the system.
            /// </param>
            /// <returns>
            /// The fetched <see cref="Member"/> object.
            /// </returns>
            public Member GetMember(string member)
            {
                IRestRequest request = new RestRequest("m/{member}/")
                    .AddUrlSegment("member", member);
                IRestResponse? response = Client.Get(request);
                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Member>(response.Content);
                    case 404:
                        throw new MemberNotFound(member);
                    default:
                        throw new Exception($"Unexpected response. {response.StatusDescription}: {(int)response.StatusCode}");
                };
            }

            /// <summary>
            /// Edits a specified member.
            /// </summary>
            /// <param name="member">
            /// A <see cref="Member"/> object to change said member to match to.
            /// </param>
            /// <returns>
            /// The edited <see cref="Member"/> object returned by the API.
            /// </returns>
            public Member SetMember(Member member)
            {
                IRestRequest request = new RestRequest("m/{member}/")
                    .AddUrlSegment("member", member.ID)
                    .AddHeader("Content-Type", "application/json");

                IRestResponse? response = Client.Patch(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Member>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        throw new MemberNotFound(member.ID);
                    default:
                        throw new HttpError(response);
                }
            }

            /// <summary>
            /// Creates a new member.
            /// </summary>
            /// <param name="member">
            /// A <see cref="Member"/> object that the new member will match.
            /// </param>
            /// <returns>
            /// The new <see cref="Member"/> object.
            /// </returns>
            public Member CreateMember(Member member)
            {
                IRestRequest request = new RestRequest("/m/")
                    .AddJsonBody(JsonConvert.SerializeObject(member))
                    .AddHeader("Content-Type", "application/json");

                IRestResponse? response = Client.Post(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        return JsonConvert.DeserializeObject<Member>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    default:
                        throw new HttpError(response);
                }
            }

            /// <summary>
            /// Deletes a system member with specified ID.
            /// </summary>
            /// <param name="member">
            /// The ID of the member to delete.
            /// </param>
            public void DeleteMember(string member)
            {
                IRestRequest request = new RestRequest("/m/{member}/")
                    .AddUrlSegment("member", member);

                IRestResponse? response = Client.Delete(request);

                switch ((int)response.StatusCode)
                {
                    case 200:
                        break;
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        throw new MemberNotFound(member);
                    default:
                        throw new HttpError(response);
                }

            }


            /// <summary>
            /// Creates a new switch.
            /// </summary>
            /// <param name="members">
            /// A array of members to be included in the switch.
            /// </param>
            public void CreateSwitch(string[] members)
            {

                IRestRequest request = new RestRequest("/s/switches")
                    .AddJsonBody(JsonConvert.SerializeObject(members));

                IRestResponse? response = Client.Post(request);

                switch ((int)response.StatusCode)
                {
                    case 204:
                        break;
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        throw new SystemNotFound();
                    default:
                        throw new HttpError(response);
                }
            }

            /// <summary>
            /// Fetches a message proxied by pluralkit.
            /// </summary>
            /// <param name="id">
            /// The ID of the message.
            /// </param>
            /// <returns>
            /// The proxied message as represented by the API.
            /// </returns>
            public Message GetMessage(string id)
            {
                IRestRequest request = new RestRequest("/msg/{id}")
                    .AddUrlSegment("id", id);

                IRestResponse? response = Client.Get(request);

                switch ((int)response.StatusCode)
                {
                    case 204:
                        return JsonConvert.DeserializeObject<Message>(response.Content);
                    case 401:
                        throw new Unauthorized();
                    case 403:
                        throw new AccessForbidden();
                    case 404:
                        throw new MessageNotFound(id);
                    default:
                        throw new HttpError(response);
                }
            }
        }
    }
}