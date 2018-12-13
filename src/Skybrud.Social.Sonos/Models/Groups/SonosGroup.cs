using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Sonos.Models.Players;

namespace Skybrud.Social.Sonos.Models.Groups {
    
    /// <summary>
    /// Class representing a list of Sonos group.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.sonos.com/reference/control-api/groups/groups/#group</cref>
    /// </see>
    public class SonosGroup : SonosObject {

        #region Properties

        /// <summary>
        /// Gets the ID that identifies a Sonos group.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Get the display name for the group, such as <strong>Living Room</strong> or <strong>Kitchen + 2</strong>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID of the player acting as the group coordinator for the group. This is a <see cref="SonosPlayer.Id"/> value.
        /// </summary>
        public string CoordinatorId { get; }

        /// <summary>
        /// Gets the playback state of the group.
        /// </summary>
        public string PlaybackState { get; }

        /// <summary>
        /// Gets the IDs of the primary players in the group. For example, only one player from each set of players
        /// bonded as a stereo pair or as satellites to a home theater setup. Each element is the ID of a player. This
        /// list includes the <see cref="CoordinatorId"/>.
        /// </summary>
        public string[] PlayerIds { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosGroup(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            CoordinatorId = obj.GetString("coordinatorId");
            PlaybackState = obj.GetString("playbackState");
            PlayerIds = obj.GetStringArray("playerIds");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosGroup"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosGroup"/>.</returns>
        public static SonosGroup Parse(JObject obj) {
            return obj == null ? null : new SonosGroup(obj);
        }

        #endregion

    }

}