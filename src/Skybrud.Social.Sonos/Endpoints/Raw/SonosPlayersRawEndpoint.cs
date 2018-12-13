using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.OAuth;

namespace Skybrud.Social.Sonos.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>players</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/playervolume/</cref>
    /// </see>
    public class SonosPlayersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SonosOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SonosPlayersRawEndpoint(SonosOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets volume information about the player with the specified <paramref name="playerId."/>
        /// </summary>
        /// <param name="playerId">The ID of the player.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/playervolume/getvolume/</cref>
        /// </see>
        public SocialHttpResponse GetVolume(string playerId) {
            if (String.IsNullOrWhiteSpace(playerId)) throw new ArgumentNullException(nameof(playerId));
            return Client.DoHttpGetRequest($"/control/api/v1/players/{playerId}/playerVolume");
        }
        
        #endregion

    }

}