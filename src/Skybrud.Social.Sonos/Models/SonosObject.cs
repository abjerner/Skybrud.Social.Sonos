using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Sonos.Models {

    /// <summary>
    /// Class representing a basic object from the Sonos API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SonosObject : JsonObjectBase {

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SonosObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SonosObject"/>.</returns>
        protected SonosObject(JObject obj) : base(obj) { }

    }

}