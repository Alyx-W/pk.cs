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
            public string? token;
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
                        return Models.System.FromJson(response.Content);
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
            /// The <see cref="Models.System.ID"/> of the system
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
            /// The id of the system whose fronters you want to fetch.
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
            /// The member to get, must be a pluralkit member id."
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
            /// 
            /// </summary>
            /// <param name="member">
            ///
            /// </param>
            /// <returns>
            ///
            /// </returns>
            public Member SetMember(Member member)
            {
                IRestRequest request = new RestRequest("m/{member}/")
                    .AddUrlSegment("member", member.ID);

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
            /// 
            /// </summary>
            /// <param name="member">
            /// 
            /// </param>
            /// <returns>
            ///
            /// </returns>
            public Member CreateMember(Member member)
            {
                IRestRequest request = new RestRequest("/m/", Method.POST);

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
            /// 
            /// </summary>
            /// <param name="member">
            /// </param>
            public void DeleteMember(string member)
            {
                IRestRequest request = new RestRequest("/m/{member}/")
                    .AddUrlSegment("member", member);

                IRestResponse? response = Client.Delete(request);

                switch ((int)response.StatusCode)
                {
                    case 204:
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
        }
    }
}