using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get a refresh token or an access token.
    /// </summary>
    public class SonosToken : SonosObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the access token. The Sonos authorization server only supports a <see cref="TokenType"/> of <c>bearer</c>.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets an instance of <see cref="TimeSpan"/> representing the time until the access token will expire.
        /// </summary>
        public TimeSpan ExpiresIn { get; }

        /// <summary>
        /// Gets a refresh token that can be used to obtain a new access tokens.
        /// </summary>
        public string RefreshToken { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
            RefreshToken = obj.GetString("refresh_token");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosToken"/>.</returns>
        public static SonosToken Parse(JObject obj) {
            return obj == null ? null : new SonosToken(obj);
        }

        #endregion

    }

}