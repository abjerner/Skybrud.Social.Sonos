using Skybrud.Social.Sonos.Endpoints.Raw;
using Skybrud.Social.Sonos.Responses.Households;

namespace Skybrud.Social.Sonos.Endpoints {
    
    /// <summary>
    /// Class representing the <strong>households</strong> endpoint.
    /// </summary>
    public class SonosHouseholdsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Sonos service.
        /// </summary>
        public SonosService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SonosHouseholdsRawEndpoint Raw => Service.Client.Households;

        #endregion

        #region Constructors

        internal SonosHouseholdsEndpoint(SonosService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of households that can be acted upon, based upon the access token used when calling the Sonos API.
        /// </summary>
        /// <returns>An instance of <see cref="SonosGetHouseholdsResponse"/> representing the response.</returns>
        public SonosGetHouseholdsResponse GetHouseholds() {
            return SonosGetHouseholdsResponse.ParseResponse(Raw.GetHouseholds());
        }

        #endregion

    }

}