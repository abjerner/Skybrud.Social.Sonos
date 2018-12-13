using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Groups {

    /// <summary>
    /// Class representing volumne information of a Sonos group.
    /// </summary>
    public class SonosGroupVolume : SonosObject {

        #region Properties

        /// <summary>
        /// A value indicating whether or not the group is muted. If <c>true</c>, the group is muted. If <c>false</c>,
        /// the group is not muted.
        /// </summary>
        public bool Fixed { get; }

        /// <summary>
        /// A value indicating whether or not the group volume is fixed or changeable. If <c>true</c>, your app cannot
        /// change the group volume. If <c>false</c>, your app can change the group volume.
        /// </summary>
        public bool Muted { get; }

        /// <summary>
        /// Group volume as an integer between <c>0</c> and <c>100</c>, inclusive.
        /// </summary>
        public int Volume { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosGroupVolume(JObject obj) : base(obj) {
            Fixed = obj.GetBoolean("fixed");
            Muted = obj.GetBoolean("muted");
            Volume = obj.GetInt32("volume");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosGroupVolume"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGroupVolume"/>.</returns>
        public static SonosGroupVolume Parse(JObject obj) {
            return obj == null ? null : new SonosGroupVolume(obj);
        }

        #endregion

    }

}