using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Models.Households;

namespace Skybrud.Social.Sonos.Responses.Households {

    /// <summary>
    /// Class representing a response with a list of Sonos households.
    /// </summary>
    public class SonosGetHouseholdsResponse : SonosResponse<SonosHouseholdList> {
        
        #region Constructors

        private SonosGetHouseholdsResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SonosHouseholdList.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SonosGetHouseholdsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGetHouseholdsResponse"/>.</returns>
        public static SonosGetHouseholdsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SonosGetHouseholdsResponse(response);
        }

        #endregion

    }

}