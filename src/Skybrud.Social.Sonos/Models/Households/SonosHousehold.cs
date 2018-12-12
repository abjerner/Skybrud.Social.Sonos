using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Sonos.Models {

    public class SonosHousehold : SonosObject {

        /// <summary>
        /// Gets the ID that identifies a Sonos household.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Get a user-displayable name of the Sonos household (not yet implemented by Sonos).
        /// </summary>
        public string Name { get; }

        protected SonosHousehold(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
        }

    }

}