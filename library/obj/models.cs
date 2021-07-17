using System;

namespace Models {
    class System {
        public string ID { get; }
        public string Name { get; }
        public string? Description { get; }
        public string? Tag { get; }
        public Uri? AvatarUrl { get; }
        public TimeZoneInfo TZ { get; }
        public DateTime Created { get; }
        public string? DescriptionPrivacy { get; }
        public string? MemberListPrivacy { get; }
        public string? FrontPrivacy { get; }
        public string? FrontHistoryPrivacy { get; }
    }
    class Member {
        public string ID { get; }
        public string Name { get; }
        public string? DisplayName { get; }
        public string? Description { get; }
        public string? Pronouns { get; }
        public Uri? AvatarUrl { get; }
        public DateTime? Birthday { get; }
        public List<ProxyTag> ProxyTags { get; }
        public bool? KeepProxy { get; }
        public DateTime Created { get; }
        public string? Privacy { get; }
        public string? NamePrivacy { get; }
        public string? DescriptionPrivacy { get; }
        public string? AvatarPrivacy { get; }
        public string? BirthdayPrivacy { get; }
        public string? PronounPrivacy { get; }
        public string? MetaDataPrivacy { get; }
    }
    class ProxyTag {
        public string? Prefix { get; }
        public string? Suffix { get; }
    }
    class SwitchIDs {
        public DateTime Timestamp { get; }
        public List<string>  Members { get; }
    }
    class SwitchMembers {
        public DateTime Timestamp { get; }
        public List<Member> Members { get; } 
    }
    class Message {
        public DateTime Timestamp { get; }
        public string ID { get; }
        public string Original { get; }
        public string Sender { get; }
        public string Channel { get; }
        public System System { get; }
        public Member Member { get; }
    }
}