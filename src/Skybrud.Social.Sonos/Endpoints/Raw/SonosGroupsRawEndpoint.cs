using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.OAuth;

namespace Skybrud.Social.Sonos.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw <strong>groups</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/groups/</cref>
    /// </see>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/group-volume/</cref>
    /// </see>
    public class SonosGroupsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SonosOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SonosGroupsRawEndpoint(SonosOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of players and groups in the household with the specified <paramref name="householdId"/>.
        /// </summary>
        /// <param name="householdId">The ID of the household.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/groups/getGroups/</cref>
        /// </see>
        public SocialHttpResponse GetGroups(string householdId) {
            if (String.IsNullOrWhiteSpace(householdId)) throw new ArgumentNullException(nameof(householdId));
            return Client.DoHttpGetRequest($"/control/api/v1/households/{householdId}/groups");
        }

        /// <summary>
        /// Gets volume information about the group with the specified <paramref name="groupId."/>
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/group-volume/getvolume/</cref>
        /// </see>
        public SocialHttpResponse GetVolume(string groupId) {
            if (String.IsNullOrWhiteSpace(groupId)) throw new ArgumentNullException(nameof(groupId));
            return Client.DoHttpGetRequest($"/control/api/v1/groups/{groupId}/groupVolume");
        }

        /// <summary>
        /// Sets the volume of the group with the specified <paramref name="groupId"/>.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="volume">A number between <c>0</c> and <c>100</c> (both inclusive) representing the volume.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/group-volume/set-volume/</cref>
        /// </see>
        public SocialHttpResponse SetVolume(string groupId, int volume) {
            if (String.IsNullOrWhiteSpace(groupId)) throw new ArgumentNullException(nameof(groupId));
            return Client.DoHttpPostRequest($"/control/api/v1/groups/{groupId}/groupVolume", new SocialHttpPostData {
                { "volume", volume }
            });
        }

        /// <summary>
        /// Sets the relative volume of the group with the specified <paramref name="groupId"/>.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="volumeDelta">A number between <c>-100</c> and <c>100</c> (including those values) indicating the amount to increase or decrease the current group volume. The group coordinator adds this value to the current group volume and then keeps the result in the range of <c>0</c> to <c>100</c>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/group-volume/set-relative-volume/</cref>
        /// </see>
        public SocialHttpResponse SetRelativeVolume(string groupId, int volumeDelta) {
            if (String.IsNullOrWhiteSpace(groupId)) throw new ArgumentNullException(nameof(groupId));
            return Client.DoHttpPostRequest($"/control/api/v1/groups/{groupId}/groupVolume/relative", new SocialHttpPostData {
                { "volumeDelta", volumeDelta }
            });
        }

        /// <summary>
        /// Sets the mute state of the group with the specified <paramref name="groupId"/>.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="mute">The desired mute state of the group: <c>true</c> for muted and <c>false</c> for not muted.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/group-volume/set-volume/</cref>
        /// </see>
        public SocialHttpResponse SetMute(string groupId, bool mute) {
            if (String.IsNullOrWhiteSpace(groupId)) throw new ArgumentNullException(nameof(groupId));
            return Client.DoHttpPostRequest($"/control/api/v1/groups/{groupId}/mute", new SocialHttpPostData {
                {"muted", mute ? "true" : "false" }
            });
        }

        #endregion

    }

}