using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models {
    public class System {
        public string ID { get; } = null!;
        public string Name { get; } = null!;
        public string? Description { get; }
        public string? Tag { get; }
        public Uri? AvatarUrl { get; }
        public TimeZoneInfo? TZ { get; }
        public DateTime Created { get; }
        public string? DescriptionPrivacy { get; }
        public string? MemberListPrivacy { get; }
        public string? FrontPrivacy { get; }
        public string? FrontHistoryPrivacy { get; }

        public static System FromJson(string json) {
            return JsonConvert.DeserializeObject <System> (json);
        }
    }
    public class Member {
        public string ID { get; } = null!;
        public string Name { get; } = null!;
        public string? DisplayName { get; }
        public string? Description { get; }
        public string? Pronouns { get; }
        public Uri? AvatarUrl { get; }
        public DateTime? Birthday { get; }
        public List<ProxyTag> ProxyTags { get; } = null!;
        public bool? KeepProxy { get; }
        public DateTime Created { get; }
        public string? Privacy { get; }
        public string? NamePrivacy { get; }
        public string? DescriptionPrivacy { get; }
        public string? AvatarPrivacy { get; }
        public string? BirthdayPrivacy { get; }
        public string? PronounPrivacy { get; }
        public string? MetaDataPrivacy { get; }

        public static Member FromJson(string json) {
            return JsonConvert.DeserializeObject <Member> (json);
        }
    }
    public class ProxyTag {
        public string? Prefix { get; }
        public string? Suffix { get; }
    }
    public class SwitchIDs {
        public DateTime Timestamp { get; }
        public List<string>  Members { get; } = null!;
    }
    public class SwitchMembers {
        public DateTime Timestamp { get; }
        public List<Member> Members { get; }  = null!;
    }
    public class Message {
        public DateTime Timestamp { get; }
        public string ID { get; } = null!;
        public string Original { get; } = null!;
        public string Sender { get; } = null!;
        public string Channel { get; } = null!;
        public System System { get; } = null!;
        public Member Member { get; } = null!;
    }
}