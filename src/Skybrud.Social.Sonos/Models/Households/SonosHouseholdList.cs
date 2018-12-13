using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models.Households {

    /// <summary>
    /// Class representing a list of Sonos households.
    /// </summary>
    public class SonosHouseholdList : SonosObject {

        #region Properties

        /// <summary>
        /// Gets an array with all households of the authenticated user.
        /// </summary>
        public SonosHousehold[] Households { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SonosHouseholdList(JObject obj) : base(obj) {
            Households = obj.GetObjectArray("households", SonosHousehold.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosHouseholdList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosHouseholdList"/>.</returns>
        public static SonosHouseholdList Parse(JObject obj) {
            return obj == null ? null : new SonosHouseholdList(obj);
        }

        #endregion

    }

}