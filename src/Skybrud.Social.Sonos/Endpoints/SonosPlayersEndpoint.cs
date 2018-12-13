using Skybrud.Social.Sonos.Endpoints.Raw;
using Skybrud.Social.Sonos.Responses.Households;
using Skybrud.Social.Sonos.Responses.Players;

namespace Skybrud.Social.Sonos.Endpoints {
    
    /// <summary>
    /// Class representing the <strong>player</strong> endpoint.
    /// </summary>
    public class SonosPlayersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Sonos service.
        /// </summary>
        public SonosService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SonosPlayersRawEndpoint Raw => Service.Client.Players;

        #endregion

        #region Constructors

        internal SonosPlayersEndpoint(SonosService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets volume information about the player with the specified <paramref name="playerId."/>
        /// </summary>
        /// <param name="playerId">The ID of the player.</param>
        /// <returns>An instance of <see cref="SonosGetPlayerVolumeResponse"/> representing the raw response.</returns>
        public SonosGetPlayerVolumeResponse GetVolume(string playerId) {
            return SonosGetPlayerVolumeResponse.ParseResponse(Raw.GetVolume(playerId));
        }

        #endregion

    }

}