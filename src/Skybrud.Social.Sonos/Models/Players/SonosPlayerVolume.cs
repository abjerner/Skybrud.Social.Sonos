using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Players {

    /// <summary>
    /// Class representing volumne information of a Sonos player or group.
    /// </summary>
    public class SonosPlayerVolume : SonosObject {

        #region Properties

        /// <summary>
        /// Indicates whether or not the volume for the player is fixed or changeable. If <c>true</c>, your app cannot
        /// change the group volume. If <c>false</c>, your app can change the group volume. For example, the CONNECT
        /// has fixed-volume line-level output.
        /// </summary>
        public bool Fixed { get; }

        /// <summary>
        /// Indicates whether or not the group is muted. If <c>true</c>, the group is muted. If <c>false</c>, the group is not muted.
        /// </summary>
        public bool Muted { get; }

        /// <summary>
        /// Indicates the volume of the player, between <c>0</c> and <c>100</c>.
        /// </summary>
        public int Volume { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosPlayerVolume(JObject obj) : base(obj) {
            Fixed = obj.GetBoolean("fixed");
            Muted = obj.GetBoolean("muted");
            Volume = obj.GetInt32("volume");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosPlayerVolume"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosPlayerVolume"/>.</returns>
        public static SonosPlayerVolume Parse(JObject obj) {
            return obj == null ? null : new SonosPlayerVolume(obj);
        }

        #endregion

    }

}