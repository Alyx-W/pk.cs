using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PluralkitAPI {
    namespace Models {
        public class System {
            /// <summary>The 5 character unique identifier. Automatically generated at creation. Non-patchable.</summary>
            [JsonProperty("id")]
            public string ID { get; set; } = null!;
            /// <summary>The system name. Required at creation. Patchable. </summary>
            [JsonProperty("name")]
            public string? Name { get; set; } = null!;
            /// <summary>The system's description. Defaults to null. Patchable.</summary>
            [JsonProperty("description")]
            public string? Description { get; set; }
            /// <summary>The system's tag (string appended to the end of names/display names when proxied). Defaults to null. Patchable. </summary>
            [JsonProperty("tag")]
            public string? Tag { get; set; }
            /// <summary>The URI of the system's avatar/default member avatar. Defaults to null. Patchable.</summary>
            [JsonProperty("avatar_url")]
            public Uri? AvatarUrl { get; set; }
            /// <summary>The TimeZoneInfo for the system's registered timezone, defaults to UTC. Patchable. </summary>
            [JsonProperty("tz")]
            public TimeZoneInfo? TZ { get; set; }
            /// <summary>The Datetime for the system's creation. Non-patchable.</summary>
            [JsonProperty("created")]
            public DateTime? Created { get; set; }
            /// <summary>The privacy of the system's description. Defaults to public. Patchable.</summary>
            [JsonProperty("description_privacy")]
            public string? DescriptionPrivacy { get; set; }
            /// <summary>The privacy of the system's member list. Defaults to public. Patchable/</summary>
            [JsonProperty("member_list_privacy")]
            public string? MemberListPrivacy { get; set; }
            /// <summary>The privacy of the system's fronters. Defaults to public. Patchable.</summary>
            [JsonProperty("front_privacy")]
            public string? FrontPrivacy { get; set; }
            /// <summary>The privacy of the system's switch history. Defaults to public. Patchable.</summary>
            [JsonProperty("front_history_privacy")]
            public string? FrontHistoryPrivacy { get; set; }

            public static Models.System FromJson(string json) {
                var jsonDict = JsonConvert.DeserializeObject <Dictionary<string, object?>> (json);
                if (jsonDict["tz"] != null) ) {
                    jsonDict["tz"] = TimeZoneInfo.FindSystemTimeZoneById(jsonDict["tz"].ToString());
                }
                string reJson = JsonConvert.SerializeObject(jsonDict);
                return JsonConvert.DeserializeObject<Models.System>(reJson);
            }
            public static Models.System FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return FromJson(json);
            }
            public string ToJson() {
                var json = JsonConvert.SerializeObject(this);
                var jsonDict = JsonConvert.DeserializeObject <Dictionary<string, object?>> (json);
                if (jsonDict["tz"].GetType() == typeof(TimeZoneInfo) ) {
                    jsonDict["tz"] = jsonDict["tz"].Id;
                }
                return JsonConvert.SerializeObject(jsonDict);
            }
            public Dictionary<string, object?> ToDict() {
                var json = JsonConvert.SerializeObject(this);
                return ToJson(json);
            }
        }

        public class Member {
            /// <summary>The 5 character unique identifier. Automatically generated at creation. Non-patchable.</summary>
            [JsonProperty("id")]
            public string ID { get; set; } = null!;
            /// <summary>The name of the member. Required at creation. Patchable.</summary>
            [JsonProperty("name")]
            public string? Name { get; set; } = null!;
            /// <summary>The display name of the member, this overrides the member's name when proxying. Defaults to null. Patchable.</summary>
            [JsonProperty("display_name")]
            public string? DisplayName { get; set; }
            /// <summary>The description of the member. Defaults to null. Patchable.</summary>
            [JsonProperty("description")]
            public string? Description { get; set; }
            /// <summary>The pronouns of the member. Defaults to null. Patchable.</summary>
            [JsonProperty("pronouns")]
            public string? Pronouns { get; set; }
            /// <summary>The URI of the member's avatar. Defaults to null. Patchable.</summary>
            [JsonProperty("avatar_url")]
            public Uri? AvatarUrl { get; set; }
            /// <summary>The member's birthday in YYYY-MM-DD format. If the year is private, returns as 0004. Defaults to null. Patchable.</summary>
            [JsonProperty("birthday")]
            public DateTime? Birthday { get; set; }
            /// <summary>The member's ProxyTags, an array of ProxyTag objects. Defaults to null. Patchable.</summary>
            [JsonProperty("proxy_tags")]
            public List<ProxyTag> ProxyTags { get; set; } = null!;
            /// <summary>Whether the proxy tags the member used to proxy the message will be kept (Will default to the highest set of proxy tags in the case of auto-proxy). Defaults to false. Patchable.</summary>
            [JsonProperty("keep_proxy")]
            public bool? KeepProxy { get; set; }
            /// <summary>The DateTime the member was created at. Non-patchable.</summary>
            [JsonProperty("created")]
            public DateTime? Created { get; set; }
            /// <summary>Whether the member's name is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("name_privacy")]
            public string? NamePrivacy { get; set; }
            /// <summary>Whether the member's description is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("description_privacy")]
            public string? DescriptionPrivacy { get; set; }
            /// <summary>Whether the member's avatar is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("avatar_privacy")]
            public string? AvatarPrivacy { get; set; }
            /// <summary>Whether the member's birthday is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("birthday_privacy")]
            public string? BirthdayPrivacy { get; set; }
            /// <summary>Whether the member's pronouns are accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("pronoun_privacy")]
            public string? PronounPrivacy { get; set; }
            /// <summary>Whether the member's metadata is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("metadata_privacy")]
            public string? MetaDataPrivacy { get; set; }

            /// <summary>Turns a json string from the API into a <see cref="Member"/></summary>
            /// <param name="json">The json string</param>
            /// <returns> A <see cref="Member"/> object.</returns>
            public static Member FromJson(string json) {
               return JsonConvert.DeserializeObject<Member>(json);
            }
            public static Member FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return JsonConvert.DeserializeObject<Member>(json);
            }
            public string ToJson() {
                return JsonConvert.SerializeObject(this);
            }
            public Dictionary<string, object> ToDict() {
                string json = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }
        
        public class ProxyTag {
            /// <summary>The prefix of the tags.</summary>
            [JsonProperty("prefix")]
            public string? Prefix { get; set; }
            /// <summary>The suffix of the tags.</summary>
            [JsonProperty("suffix")]
            public string? Suffix { get; set; }

            /// <summary>Turns a json string from the API into a <see cref="ProxyTag"/></summary>
            public static ProxyTag FromJson(string json) {
               return JsonConvert.DeserializeObject<ProxyTag>(json);
            }
            public static ProxyTag FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return JsonConvert.DeserializeObject<ProxyTag>(json);
            }
            public string ToJson() {
                return JsonConvert.SerializeObject(this);
            }
            public Dictionary<string, object> ToDict() {
                string json = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }

        public class Switches {
            /// <summary>The time the switch was logged at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; set; }
            /// <summary>The members (IDs) currently fronting at the time of the switch.</summary>
            [JsonProperty("members")]
            public List<string>  Members { get; set; } = null!;

            public static Switches FromJson(string json) {
               return JsonConvert.DeserializeObject<Switches>(json);
            }
            public static Switches FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return JsonConvert.DeserializeObject<Switches>(json);
            }
            public string ToJson() {
                return JsonConvert.SerializeObject(this);
            }
            public Dictionary<string, object> ToDict() {
                string json = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }

        public class Fronters {
            /// <summary>The the most recent switch was logged at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; set; }
            /// <summary>The members (objects) currently fronting at the time of the query.</summary>
            [JsonProperty("members")]
            public List<Member> Members { get; set; }  = null!;

            public static Fronters FromJson(string json) {
               return JsonConvert.DeserializeObject<Fronters>(json);
            }
            public static Fronters FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return JsonConvert.DeserializeObject<Fronters>(json);
            }
            public string ToJson() {
                return JsonConvert.SerializeObject(this);
            }
            public Dictionary<string, object> ToDict() {
                string json = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }

        public class Message {
            /// <summary>The time the message was sent at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; set; }
            /// <summary>The proxied message's snowflake ID, generated by discord.</summary>
            [JsonProperty("id")]
            public string ID { get; set; } = null!;
            /// <summary>The original message's snowflake ID, generated by discord.</summary>
            [JsonProperty("original")]
            public string Original { get; set; } = null!;
            /// <summary>The discord snowflake ID of the account who sent the original message.</summary>
            [JsonProperty("sender")]
            public string Sender { get; set; } = null!;
            /// <summary>The discord snowflake ID of the channel that the message was sent in.</summary>
            [JsonProperty("channel")]
            public string Channel { get; set; } = null!;
            /// <summary>The system that sent the message.</summary>
            [JsonProperty("system")]
            public System System { get; set; } = null!;
            /// <summary>The member that sent the message.</summary>
            [JsonProperty("member")]
            public Member Member { get; set; } = null!;

            public static Message FromJson(string json) {
               return JsonConvert.DeserializeObject<Message>(json);
            }
            public static Message FromDict(Dictionary<string, object> dict) {
                var json = JsonConvert.SerializeObject(dict);
                return JsonConvert.DeserializeObject<Message>(json);
            }
            public string ToJson() {
                return JsonConvert.SerializeObject(this);
            }
            public Dictionary<string, object> ToDict() {
                string json = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }
    }
}