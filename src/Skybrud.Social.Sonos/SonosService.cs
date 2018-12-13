using System;
using Skybrud.Social.Sonos.Endpoints;
using Skybrud.Social.Sonos.OAuth;

namespace Skybrud.Social.Sonos {

    /// <summary>
    /// Class working as an entry point to the Sonos API.
    /// </summary>
    public class SonosService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client.
        /// </summary>
        public SonosOAuthClient Client { get; }
        
        /// <summary>
        /// Gets a reference to the <strong>groups</strong> endpoint.
        /// </summary>
        public SonosGroupsEndpoint Groups { get; }

        /// <summary>
        /// Gets a reference to the <strong>households</strong> endpoint.
        /// </summary>
        public SonosHouseholdsEndpoint Households { get; }

        /// <summary>
        /// Gets a reference to the <strong>players</strong> endpoint.
        /// </summary>
        public SonosPlayersEndpoint Players { get; }

        #endregion

        #region Constructors

        private SonosService(SonosOAuthClient client) {
            Client = client;
            Groups = new SonosGroupsEndpoint(this);
            Households = new SonosHouseholdsEndpoint(this);
            Players = new SonosPlayersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>The created instance of <see cref="SonosService" />.</returns>
        public static SonosService CreateFromOAuthClient(SonosOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new SonosService(client);
        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The created instance of <see cref="SonosService" />.</returns>
        public static SonosService CreateFromAccessToken(string accessToken) {
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new SonosService(new SonosOAuthClient(accessToken));
        }

        ///// <summary>
        ///// Initializes a new instance based on the specified <paramref name="refreshToken"/>.
        ///// </summary>
        ///// <param name="clientId">The client ID.</param>
        ///// <param name="clientSecret">The client secret.</param>
        ///// <param name="refreshToken">The refresh token of the user.</param>
        ///// <returns>The created instance of <see cref="Skybrud.Social.Sonos.SonosService" />.</returns>
        //public static SonosService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

        //    if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
        //    if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
        //    if (String.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

        //    // Initialize a new OAuth client
        //    SonosOAuthClient client = new SonosOAuthClient(clientId, clientSecret);

        //    // Get an access token from the refresh token.
        //    SonosTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

        //    // Update the OAuth client with the access token
        //    client.AccessToken = response.Body.AccessToken;

        //    // Initialize a new service instance
        //    return new SonosService(client);

        //}

        #endregion

    }

}