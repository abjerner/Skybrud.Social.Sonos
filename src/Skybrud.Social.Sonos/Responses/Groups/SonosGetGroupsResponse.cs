using System;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Exceptions;
using Skybrud.Social.Sonos.Models.Groups;

namespace Skybrud.Social.Sonos.Responses.Groups {

    /// <summary>
    /// Class representing a response with a list of Sonos groups.
    /// </summary>
    public class SonosGetGroupsResponse : SonosResponse<SonosGroupList> {
        
        #region Constructors

        private SonosGetGroupsResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SonosGroupList.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SonosGetGroupsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGetGroupsResponse"/>.</returns>
        public static SonosGetGroupsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SonosGetGroupsResponse(response);
        }

        #endregion

    }

}