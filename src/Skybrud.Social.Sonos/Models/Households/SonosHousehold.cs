using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Households {

    /// <summary>
    /// Class representing a list of Sonos household.
    /// </summary>
    public class SonosHousehold : SonosObject {

        #region Properties

        /// <summary>
        /// Gets the ID that identifies a Sonos household.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Get a user-displayable name of the Sonos household (not yet implemented by Sonos).
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosHousehold(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosHousehold"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosHousehold"/>.</returns>
        public static SonosHousehold Parse(JObject obj) {
            return obj == null ? null : new SonosHousehold(obj);
        }

        #endregion

    }

}