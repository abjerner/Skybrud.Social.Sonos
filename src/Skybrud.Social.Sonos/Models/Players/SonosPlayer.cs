using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Players {
    
    /// <summary>
    /// Class representing a Sonos player.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/groups/groups/#player</cref>
    /// </see>
    public class SonosPlayer : SonosObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the player.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Get the display name for the player. For example, <strong>Living Room</strong>, <strong>Kitchen</strong>, or <strong>Dining Room</strong>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Get the secure WebSocket URL for the device.
        /// </summary>
        public string WebsocketUrl { get; }

        /// <summary>
        /// Get the REST URL of the player.
        /// </summary>
        public string RestUrl { get; }

        /// <summary>
        /// Get the software version of the player.
        /// </summary>
        public string SoftwareVersion { get; }

        /// <summary>
        /// Get the IDs of all bonded devices corresponding to this logical player.
        /// </summary>
        public string[] DeviceIds { get; }

        /// <summary>
        /// Get the highest API version supported by the player.
        /// </summary>
        public string ApiVersion { get; }

        /// <summary>
        /// Get the lowest API version supported by the player.
        /// </summary>
        public string MinApiVersion { get; }

        /// <summary>
        /// Get the capabilities provided by the player.
        /// </summary>
        public string[] Capabilities { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosPlayer(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            WebsocketUrl = obj.GetString("websocketUrl");
            RestUrl = obj.GetString("restUrl");
            SoftwareVersion = obj.GetString("softwareVersion");
            DeviceIds = obj.GetStringArray("deviceIds");
            ApiVersion = obj.GetString("apiVersion");
            MinApiVersion = obj.GetString("minApiVersion");
            Capabilities = obj.GetStringArray("capabilities");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosPlayer"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosPlayer"/>.</returns>
        public static SonosPlayer Parse(JObject obj) {
            return obj == null ? null : new SonosPlayer(obj);
        }

        #endregion

    }

}