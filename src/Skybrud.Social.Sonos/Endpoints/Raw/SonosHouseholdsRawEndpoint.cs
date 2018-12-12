using Skybrud.Social.Http;
using Skybrud.Social.Sonos.OAuth;

namespace Skybrud.Social.Sonos.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw <strong>households</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/households/</cref>
    /// </see>
    public class SonosHouseholdsRawEndpoint {

        #region Properties

        public SonosOAuthClient Client { get; }

        #endregion

        #region Constructors

        public SonosHouseholdsRawEndpoint(SonosOAuthClient client) {
            Client = client;
        }

        #endregion

        public SocialHttpResponse GetHouseholds() {
            return Client.DoHttpGetRequest("/control/api/v1/households");
        }

    }

}