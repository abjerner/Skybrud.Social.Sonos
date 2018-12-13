using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Sonos.Models.Players;

namespace Skybrud.Social.Sonos.Models.Groups {

    /// <summary>
    /// Class representing a list of groups and players of a Sonos household.
    /// </summary>
    public class SonosGroupList : SonosObject {

        #region Properties

        /// <summary>
        /// Gets an array with all player groups of the parent household.
        /// </summary>
        public SonosGroup[] Groups { get; }

        /// <summary>
        /// Gets an array with all players of the parent household.
        /// </summary>
        public SonosPlayer[] Players { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosGroupList(JObject obj) : base(obj) {
            Groups = obj.GetObjectArray("groups", SonosGroup.Parse);
            Players = obj.GetObjectArray("players", SonosPlayer.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosGroupList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGroupList"/>.</returns>
        public static SonosGroupList Parse(JObject obj) {
            return obj == null ? null : new SonosGroupList(obj);
        }

        #endregion

    }

}