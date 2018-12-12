using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Security;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Sonos.Endpoints.Raw;
using Skybrud.Social.Sonos.Responses.Authentication;

namespace Skybrud.Social.Sonos.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Sonos API as well as any OAuth 2.0 communication.
    /// </summary>
    public class SonosOAuthClient : SocialHttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID of the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>households</strong> endpoint.
        /// </summary>
        public SonosHouseholdsRawEndpoint Households { get; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client with default options.
        /// </summary>
        public SonosOAuthClient() {
            Households = new SonosHouseholdsRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public SonosOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }
        
        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/> and
        /// <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SonosOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/>,
        /// <paramref name="clientSecret"/> and <paramref name="redirectUri"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SonosOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">The state to send to the Sonos OAuth login page.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {

            // Input validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            
            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Construct the query string
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("response_type", "code");
            query.Add("scope", "playback-control-all");
            query.Add("state", state);

            // Construct the authorization URL
            return "https://api.sonos.com/login/v3/oauth?" + query;

        }

        /// <summary>
        /// Exchanges the specified <paramref name="authorizationCode"/> for a refresh token and an access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the Sonos OAuth dialog.</param>
        /// <returns>An instance of <see cref="SonosTokenResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/authorization-api/create-token/</cref>
        /// </see>
        public SonosTokenResponse GetAccessTokenFromAuthorizationCode(string authorizationCode) {

            // Input validation
            if (String.IsNullOrWhiteSpace(authorizationCode)) throw new ArgumentNullException(nameof(authorizationCode));
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Initialize the POST data
            SocialHttpPostData postData = new SocialHttpPostData {
                {"grant_type", "authorization_code"},
                {"code", authorizationCode},
                {"redirect_uri", RedirectUri}
            };

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = "https://api.sonos.com/login/v3/oauth/access",
                PostData = postData
            };

            // Update the "Authorization" header
            request.Authorization = "Basic " + SecurityUtils.Base64Encode(ClientId + ":" + ClientSecret);

            // Make a request to the server
            SocialHttpResponse response = request.GetResponse();

            // Parse the JSON response
            return SonosTokenResponse.ParseResponse(response);

        }
        
        /// <summary>
        /// Updates the request with information specific to the Sonos API.
        /// </summary>
        /// <param name="request">The request.</param>
        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            base.PrepareHttpRequest(request);

            //// Append the scheme and host name if not already present
            if (request.Url.StartsWith("/control/")) request.Url = "https://api.ws.sonos.com" + request.Url;

            // Append the access token (if specified)
            if (!String.IsNullOrWhiteSpace(AccessToken)) request.Authorization = "Bearer " + AccessToken;

        }

        #endregion

    }

}