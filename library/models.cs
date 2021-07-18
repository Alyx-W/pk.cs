using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models {
    public class System {
        /// <summary>The 5 character unique identifier.</summary>
        [JsonProperty("id")]
        public string ID { get; } = null!;
        /// <summary>The system name.</summary>
        [JsonProperty("name")]
        public string Name { get; } = null!;
        /// <summary>The system's description. Defaults to null.</summary>
        [JsonProperty("description")]
        public string? Description { get; }
        /// <summary>The system's tag (string appended to the end of names/display names when proxied). Defaults to null.</summary>
        [JsonProperty("tag")]
        public string? Tag { get; }
        /// <summary>The URI of the system's avatar/default member avatar. Defaults to null.</summary>
        [JsonProperty("avatar_url")]
        public Uri? AvatarUrl { get; }
        /// <summary>The TimeZoneInfo for the system's registered timezone, defaults to UTC.</summary>
        [JsonProperty("tz")]
        public TimeZoneInfo? TZ { get; }
        /// <summary>The Datetime for the system's creation.</summary>
        [JsonProperty("created")]
        public DateTime Created { get; }
        /// <summary>The privacy of the system's description. Defaults to public.</summary>
        [JsonProperty("description_privacy")]
        public string? DescriptionPrivacy { get; }
        /// <summary>The privacy of the system's member list. Defaults to public.</summary>
        [JsonProperty("member_list_privacy")]
        public string? MemberListPrivacy { get; }
        /// <summary>The privacy of the system's fronters. Defaults to public.</summary>
        [JsonProperty("front_privacy")]
        public string? FrontPrivacy { get; }
        /// <summary>The privacy of the system's switch history. Defaults to public.</summary>
        [JsonProperty("front_history_privacy")]
        public string? FrontHistoryPrivacy { get; }

        public static System FromJson(string json) {
            return JsonConvert.DeserializeObject <System> (json);
        }
    }
    public class Member {
        /// <summary>The 5 character unique identifier.</summary>
        [JsonProperty("id")]
        public string ID { get; } = null!;
        /// <summary>The name of the member.</summary>
        [JsonProperty("name")]
        public string Name { get; } = null!;
        /// <summary>The display name of the member, this overrides the member's name when proxying. Defaults to null.</summary>
        [JsonProperty("display_name")]
        public string? DisplayName { get; }
        /// <summary>The description of the member. Defaults to null</summary>
        [JsonProperty("description")]
        public string? Description { get; }
        /// <summary>The pronouns of the member. Defaults to null.</summary>
        [JsonProperty("pronouns")]
        public string? Pronouns { get; }
        /// <summary>The URI of the member's avatar. Defaults to null.</summary>
        [JsonProperty("avatar_url")]
        public Uri? AvatarUrl { get; }
        /// <summary>The member's birthday in YYYY-MM-DD format. If the year is private, returns as 0004. Defaults to null.</summary>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; }
        /// <summary>The member's ProxyTags, </summary>
        [JsonProperty("proxy_tags")]
        public List<ProxyTag> ProxyTags { get; } = null!;
        /// <summary></summary>
        [JsonProperty("keep_proxy")]
        public bool? KeepProxy { get; }
        /// <summary></summary>
        [JsonProperty("created")]
        public DateTime Created { get; }
        /// <summary></summary>
        [JsonProperty("privacy")]
        public string? Privacy { get; }
        /// <summary></summary>
        [JsonProperty("name_privacy")]
        public string? NamePrivacy { get; }
        /// <summary></summary>
        [JsonProperty("description_privacy")]
        public string? DescriptionPrivacy { get; }
        /// <summary></summary>
        [JsonProperty("avatar_privacy")]
        public string? AvatarPrivacy { get; }
        /// <summary></summary>
        [JsonProperty("birthday_privacy")]
        public string? BirthdayPrivacy { get; }
        /// <summary></summary>
        [JsonProperty("pronoun_privacy")]
        public string? PronounPrivacy { get; }
        /// <summary></summary>
        [JsonProperty("metadata_privacy")]
        public string? MetaDataPrivacy { get; }

        public static Member FromJson(string json) {
            return JsonConvert.DeserializeObject <Member> (json);
        }
    }
    public class ProxyTag {
        /// <summary></summary>
        [JsonProperty("prefix")]
        public string? Prefix { get; }
        /// <summary></summary>
        [JsonProperty("suffix")]
        public string? Suffix { get; }
    }
    public class Switches {
        /// <summary></summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; }
        /// <summary></summary>
        [JsonProperty("members")]
        public List<string>  Members { get; } = null!;
    }
    public class Fronters {
        /// <summary></summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; }
        /// <summary></summary>
        [JsonProperty("members")]
        public List<Member> Members { get; }  = null!;
    }
    public class Message {
        /// <summary></summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; }
        /// <summary></summary>
        [JsonProperty("id")]
        public string ID { get; } = null!;
        /// <summary></summary>
        [JsonProperty("original")]
        public string Original { get; } = null!;
        /// <summary></summary>
        [JsonProperty("sender")]
        public string Sender { get; } = null!;
        /// <summary></summary>
        [JsonProperty("channel")]
        public string Channel { get; } = null!;
        /// <summary></summary>
        [JsonProperty("system")]
        public System System { get; } = null!;
        /// <summary></summary>
        [JsonProperty("member")]
        public Member Member { get; } = null!;
    }
}