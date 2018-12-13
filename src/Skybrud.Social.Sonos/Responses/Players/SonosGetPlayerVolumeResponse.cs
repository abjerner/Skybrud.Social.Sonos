using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Exceptions;
using Skybrud.Social.Sonos.Models.Players;

namespace Skybrud.Social.Sonos.Responses.Players {

    /// <summary>
    /// Class representing a response with volume information of a Sonos player.
    /// </summary>
    public class SonosGetPlayerVolumeResponse : SonosResponse<SonosPlayerVolume> {
        
        #region Constructors

        private SonosGetPlayerVolumeResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SonosPlayerVolume.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SonosGetPlayerVolumeResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGetPlayerVolumeResponse"/>.</returns>
        public static SonosGetPlayerVolumeResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SonosGetPlayerVolumeResponse(response);
        }

        #endregion

    }

}