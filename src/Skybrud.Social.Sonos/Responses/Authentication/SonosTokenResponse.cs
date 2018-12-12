using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Models.Authentication;

namespace Skybrud.Social.Sonos.Responses.Authentication {
    
    /// <summary>
    /// Class representing a token response received from the Sonos API.
    /// </summary>
    public class SonosTokenResponse : SonosResponse<SonosToken> {
        
        #region Constructors

        private SonosTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, SonosToken.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SonosTokenResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SonosTokenResponse"/>.</returns>
        public static SonosTokenResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SonosTokenResponse(response);
        }

        #endregion

    }

}