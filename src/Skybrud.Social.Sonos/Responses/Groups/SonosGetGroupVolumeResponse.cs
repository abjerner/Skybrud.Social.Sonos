using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Exceptions;
using Skybrud.Social.Sonos.Models.Groups;
using Skybrud.Social.Sonos.Models.Players;

namespace Skybrud.Social.Sonos.Responses.Groups {

    /// <summary>
    /// Class representing a response with volume information of a Sonos group.
    /// </summary>
    public class SonosGetGroupVolumeResponse : SonosResponse<SonosGroupVolume> {
        
        #region Constructors

        private SonosGetGroupVolumeResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SonosGroupVolume.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SonosGetGroupVolumeResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGetGroupVolumeResponse"/>.</returns>
        public static SonosGetGroupVolumeResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SonosGetGroupVolumeResponse(response);
        }

        #endregion

    }

}