using Skybrud.Social.Http;
using Skybrud.Social.Sonos.OAuth;

namespace Skybrud.Social.Sonos.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of <strong>households</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/households/</cref>
    /// </see>
    public class SonosHouseholdsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SonosOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SonosHouseholdsRawEndpoint(SonosOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of households that can be acted upon, based upon the access token used when calling the Sonos API.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.sonos.com/reference/control-api/households/</cref>
        /// </see>
        public SocialHttpResponse GetHouseholds() {
            return Client.DoHttpGetRequest("/control/api/v1/households");
        }

        #endregion

    }

}