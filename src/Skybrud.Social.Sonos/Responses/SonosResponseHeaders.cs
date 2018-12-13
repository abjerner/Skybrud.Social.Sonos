using Skybrud.Social.Http;

namespace Skybrud.Social.Sonos.Responses {

    public class SonosResponseHeaders : SocialHttpHeaderCollection {

        public string GroupId { get; }

        public string HouseholdId { get; }

        public string Mac { get; }

        public string Session { get; }

        public string Type { get; }

        public string UserId { get; }

        public SonosResponseHeaders(SocialHttpResponse response) : base(response.Response.Headers) {
            GroupId = response.Headers["X-Sonos-Group-Id"];
            HouseholdId = response.Headers["X-Sonos-Household-Id"];
            Mac = response.Headers["X-Sonos-MAC"];
            Session = response.Headers["X-Sonos-Session"];
            Type = response.Headers["X-Sonos-Type"];
            UserId = response.Headers["X-Sonos-User-Id"];
        }

    }

}