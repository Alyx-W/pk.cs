using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PluralkitAPI {
    namespace Models {
        public class System {
            /// <summary>The 5 character unique identifier. Automatically generated at creation. Non-patchable.</summary>
            [JsonProperty("id")]
            public string ID { get; } = null!;
            /// <summary>The system name. Required at creation. Patchable. </summary>
            [JsonProperty("name")]
            public string Name { get; }
            /// <summary>The system's description. Defaults to null. Patchable.</summary>
            [JsonProperty("description")]
            public string? Description { get; }
            /// <summary>The system's tag (string appended to the end of names/display names when proxied). Defaults to null. Patchable. </summary>
            [JsonProperty("tag")]
            public string? Tag { get; }
            /// <summary>The URI of the system's avatar/default member avatar. Defaults to null. Patchable.</summary>
            [JsonProperty("avatar_url")]
            public Uri? AvatarUrl { get; }
            /// <summary>The TimeZoneInfo for the system's registered timezone, defaults to UTC. Patchable. </summary>
            [JsonProperty("tz")]
            public TimeZoneInfo? TZ { get; }
            /// <summary>The Datetime for the system's creation. Non-patchable.</summary>
            [JsonProperty("created")]
            public DateTime Created { get; }
            /// <summary>The privacy of the system's description. Defaults to public. Patchable.</summary>
            [JsonProperty("description_privacy")]
            public string? DescriptionPrivacy { get; }
            /// <summary>The privacy of the system's member list. Defaults to public. Patchable/</summary>
            [JsonProperty("member_list_privacy")]
            public string? MemberListPrivacy { get; }
            /// <summary>The privacy of the system's fronters. Defaults to public. Patchable.</summary>
            [JsonProperty("front_privacy")]
            public string? FrontPrivacy { get; }
            /// <summary>The privacy of the system's switch history. Defaults to public. Patchable.</summary>
            [JsonProperty("front_history_privacy")]
            public string? FrontHistoryPrivacy { get; }

            public static System FromJson(string json) {
                return JsonConvert.DeserializeObject <System> (json);
            }
        }
        public class Member {
            /// <summary>The 5 character unique identifier. Automatically generated at creation. Non-patchable.</summary>
            [JsonProperty("id")]
            public string ID { get; } = null!;
            /// <summary>The name of the member. Required at creation. Patchable.</summary>
            [JsonProperty("name")]
            public string Name { get; } = null!;
            /// <summary>The display name of the member, this overrides the member's name when proxying. Defaults to null. Patchable.</summary>
            [JsonProperty("display_name")]
            public string? DisplayName { get; }
            /// <summary>The description of the member. Defaults to null. Patchable.</summary>
            [JsonProperty("description")]
            public string? Description { get; }
            /// <summary>The pronouns of the member. Defaults to null. Patchable.</summary>
            [JsonProperty("pronouns")]
            public string? Pronouns { get; }
            /// <summary>The URI of the member's avatar. Defaults to null. Patchable.</summary>
            [JsonProperty("avatar_url")]
            public Uri? AvatarUrl { get; }
            /// <summary>The member's birthday in YYYY-MM-DD format. If the year is private, returns as 0004. Defaults to null. Patchable.</summary>
            [JsonProperty("birthday")]
            public DateTime? Birthday { get; }
            /// <summary>The member's ProxyTags, an array of ProxyTag objects. Defaults to null. Patchable.</summary>
            [JsonProperty("proxy_tags")]
            public List<ProxyTag> ProxyTags { get; } = null!;
            /// <summary>Whether the proxy tags the member used to proxy the message will be kept (Will default to the highest set of proxy tags in the case of auto-proxy). Defaults to false. Patchable.</summary>
            [JsonProperty("keep_proxy")]
            public bool? KeepProxy { get; }
            /// <summary>The DateTime the member was created at. Non-patchable.</summary>
            [JsonProperty("created")]
            public DateTime Created { get; }
            /// <summary>Whether the member's name is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("name_privacy")]
            public string? NamePrivacy { get; }
            /// <summary>Whether the member's description is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("description_privacy")]
            public string? DescriptionPrivacy { get; }
            /// <summary>Whether the member's avatar is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("avatar_privacy")]
            public string? AvatarPrivacy { get; }
            /// <summary>Whether the member's birthday is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("birthday_privacy")]
            public string? BirthdayPrivacy { get; }
            /// <summary>Whether the member's pronouns are accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("pronoun_privacy")]
            public string? PronounPrivacy { get; }
            /// <summary>Whether the member's metadata is accesible without authorization (Token, or -all flag on discord)</summary>
            [JsonProperty("metadata_privacy")]
            public string? MetaDataPrivacy { get; }

            public static Member FromJson(string json) {
                return JsonConvert.DeserializeObject <Member> (json);
            }
        }
        public class ProxyTag {
            /// <summary>The prefix of the tags.</summary>
            [JsonProperty("prefix")]
            public string? Prefix { get; }
            /// <summary>The suffix of the tags.</summary>
            [JsonProperty("suffix")]
            public string? Suffix { get; }
        }
        public class Switches {
            /// <summary>The time the switch was logged at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; }
            /// <summary>The members (IDs) currently fronting at the time of the switch.</summary>
            [JsonProperty("members")]
            public List<string>  Members { get; } = null!;
        }
        public class Fronters {
            /// <summary>The the most recent switch was logged at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; }
            /// <summary>The members (objects) currently fronting at the time of the query.</summary>
            [JsonProperty("members")]
            public List<Member> Members { get; }  = null!;
        }
        public class Message {
            /// <summary>The time the message was sent at.</summary>
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; }
            /// <summary>The proxied message's snowflake ID, generated by discord.</summary>
            [JsonProperty("id")]
            public string ID { get; } = null!;
            /// <summary>The original message's snowflake ID, generated by discord.</summary>
            [JsonProperty("original")]
            public string Original { get; } = null!;
            /// <summary>The discord snowflake ID of the account who sent the original message.</summary>
            [JsonProperty("sender")]
            public string Sender { get; } = null!;
            /// <summary>The discord snowflake ID of the channel that the message was sent in.</summary>
            [JsonProperty("channel")]
            public string Channel { get; } = null!;
            /// <summary>The system that sent the message.</summary>
            [JsonProperty("system")]
            public System System { get; } = null!;
            /// <summary>The member that sent the message.</summary>
            [JsonProperty("member")]
            public Member Member { get; } = null!;
        }
    }
}